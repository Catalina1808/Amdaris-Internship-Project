using AutoMapper;
using BookLoversProject.Application.Commands.Create.CreateUserCommand;
using BookLoversProject.Application.Commands.Delete.DeleteUserCommand;
using BookLoversProject.Application.Commands.Update.UpdateUserCommand;
using BookLoversProject.Application.DTO.UserDTOs;
using BookLoversProject.Application.Queries.GetShelvesByUserIdQuery;
using BookLoversProject.Application.Queries.GetUserByIdQuery;
using BookLoversProject.Application.Queries.GetUsersQuery;
using BookLoversProject.Domain.Domain;
using BookLoversProject.Presentation.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookLoversProject.Api.Controllers
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
            var userExists = await _userManager.FindByEmailAsync(user.Email);
            if(userExists != null)
            {
                return BadRequest("User with this email aready exists!");
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

            return Ok(new { userId = newUser.Id});
        }

        [HttpPost]
        [Route("AssignRole")]
        public async Task<IActionResult> AddToRole(string userId, string roleName)
        {
            var userExists = await _userManager.FindByIdAsync(userId);

            if(userExists == null)
            {
                return BadRequest("User does not exist!");
            }

            await _roleManager.CreateAsync(new IdentityRole
            {
                Name = roleName,
            });

            var addRoleToUser = await _userManager.AddToRoleAsync(userExists, roleName);

            if(!addRoleToUser.Succeeded) {
                return BadRequest("Failed to add user to role");
            }

            return Ok($"User added successfully to {roleName} role");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(string userName, string password)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if((user != null) && await _userManager.CheckPasswordAsync(user, password))
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
        public async Task<IActionResult> GetAll()
        {
            var query = new GetUsersQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
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
            var command = _mapper.Map<UpdateUserCommand>(updatedUser);
            command.Id = userId;

            var result = await _mediator.Send(command);

            return Ok(result);
        }


        [HttpDelete]
        [Route("{userId}")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var command = new DeleteUserCommand { Id = userId };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
