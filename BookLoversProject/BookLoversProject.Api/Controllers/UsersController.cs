using AutoMapper;
using BookLoversProject.Application.Commands.Create.CreateUserCommand;
using BookLoversProject.Application.Commands.Delete.DeleteUserCommand;
using BookLoversProject.Application.Commands.Update.UpdateUserCommand;
using BookLoversProject.Application.DTO.BookDTOs;
using BookLoversProject.Application.DTO.UserDTOs;
using BookLoversProject.Application.Queries.GetBooksCount;
using BookLoversProject.Application.Queries.GetPagedBooksQuery;
using BookLoversProject.Application.Queries.GetShelvesByUserIdQuery;
using BookLoversProject.Application.Queries.GetUserByIdQuery;
using BookLoversProject.Application.Queries.GetUsersCount;
using BookLoversProject.Application.Queries.GetUsersQuery;
using BookLoversProject.Application.Wrappers;
using BookLoversProject.Domain.Domain;
using BookLoversProject.Presentation.Filters;
using BookLoversProject.Presentation.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace BookLoversProject.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersController(
            IMediator mediator,
            IMapper mapper,
            ITokenService tokenService,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _mediator = mediator;
            _mapper = mapper;
            _tokenService = tokenService;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> CreateUser([FromBody] UserPutPostDTO user)
        {
            var userEmailExists = await _userManager.FindByEmailAsync(user.Email);
            var userUsernameExists = await _userManager.FindByNameAsync(user.UserName);
            if (userEmailExists != null)
            {
                return BadRequest("User with this email aready exists!");
            }

            if (userUsernameExists != null)
            {
                return BadRequest("User with this username aready exists!");
            }

            User newUser = new User
            {
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                ImagePath = user.ImagePath

            };
            var identityResult = await _userManager.CreateAsync(newUser, user.Password);
            if (!identityResult.Succeeded)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            //foreach(var role in roles)
            //{
            //    await _roleManager.CreateAsync(new IdentityRole
            //    {
            //        Name = role,
            //    });
            //    var addRoleToUser = await _userManager.AddToRoleAsync(newUser, role);

            //    if (!addRoleToUser.Succeeded)
            //    {
            //        return BadRequest("Failed to add user to role");
            //    }
            //}

            //var userToken = _tokenService.CreateToken(newUser, roles);

            return Ok(new { userId = newUser.Id });
        }

        [HttpPost]
        [Route("AssignRole")]
        public async Task<IActionResult> AddToRole(string userId, string roleName)
        {
            var userExists = await _userManager.FindByIdAsync(userId);

            if (userExists == null)
            {
                return BadRequest("User does not exist!");
            }

            await _roleManager.CreateAsync(new IdentityRole
            {
                Name = roleName,
            });

            var addRoleToUser = await _userManager.AddToRoleAsync(userExists, roleName);

            if (!addRoleToUser.Succeeded)
            {
                return BadRequest("Failed to add user to role");
            }

            return Ok($"User added successfully to {roleName} role");
        }

        [HttpGet]
        [Route("{userId}/Roles")]
        public async Task<IActionResult> GetRoles(string userId)
        {
            var userExists = await _userManager.FindByIdAsync(userId);

            if (userExists == null)
            {
                return BadRequest("User does not exist!");
            }

            var roles = await _userManager.GetRolesAsync(userExists);

            return Ok(roles);
        }

        [HttpDelete]
        [Route("DeleteRole")]
        public async Task<IActionResult> DeleteFromRole(string userId, string roleName)
        {
            var userExists = await _userManager.FindByIdAsync(userId);

            if (userExists == null)
            {
                return BadRequest("User does not exist!");
            }

            var deleyeRoleFromUser = await _userManager.RemoveFromRoleAsync(userExists, roleName);

            if (!deleyeRoleFromUser.Succeeded)
            {
                return BadRequest("Failed to add user to role");
            }

            return Ok($"User added successfully to {roleName} role");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(string userName, string password)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var userToken = _tokenService.CreateToken(user, userRoles);
                return Ok(new
                {
                    token = userToken
                });
            }
            return Unauthorized();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var query = new GetUsersQuery
            {
                PageNumber = validFilter.PageNumber,
                PageSize = validFilter.PageSize
            };
            var pagedData = await _mediator.Send(query);
            var totalRecords = await _mediator.Send(new GetUsersCountQuery());
            var totalPages = (double)totalRecords / (double)validFilter.PageSize;
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));

            return Ok(new PagedResponse<IEnumerable<UserGetDTO>>(pagedData, validFilter.PageNumber, validFilter.PageSize, roundedTotalPages));
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetById(string userId)
        {
            var query = new GetUserByIdQuery { Id = userId };
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [Route("{userId}/Shelves")]
        public async Task<IActionResult> GetShelvesByUserId(string userId)
        {
            var query = new GetShelvesByUserIdQuery { UserId = userId };
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPut]
        [Route("{userId}")]
        public async Task<IActionResult> UpdateUser(string userId, [FromBody] UserPutPostDTO updatedUser)
        {
            var oldUser = await _userManager.FindByIdAsync(userId);
            var userEmailExists = await _userManager.FindByEmailAsync(updatedUser.Email);
            var userUsernameExists = await _userManager.FindByNameAsync(updatedUser.UserName);

            if (userEmailExists != null && oldUser.Email != updatedUser.Email)
            {
                return BadRequest("User with this email aready exists!");
            }

            if (userUsernameExists != null && oldUser.UserName != updatedUser.UserName)
            {
                return BadRequest("User with this username aready exists!");
            }

            oldUser.UserName = updatedUser.UserName;
            oldUser.Email = updatedUser.Email;
            oldUser.FirstName = updatedUser.FirstName;
            oldUser.LastName = updatedUser.LastName;
            oldUser.ImagePath = updatedUser.ImagePath;

            var identityResult = await _userManager.UpdateAsync(oldUser);
            if (!identityResult.Succeeded)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            return Ok(new { userId = oldUser.Id });
        }


        [HttpDelete]
        [Route("{userId}")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var userExists = await _userManager.FindByIdAsync(userId);
            if (userExists != null)
            {
                await _userManager.DeleteAsync(userExists);
            }

            return NoContent();
        }
    }
}
