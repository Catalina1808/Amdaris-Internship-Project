using AutoMapper;
using BookLoversProject.Application.Commands.Create.CreateUserCommand;
using BookLoversProject.Application.Commands.Delete.DeleteUserCommand;
using BookLoversProject.Application.Commands.Update.UpdateUserCommand;
using BookLoversProject.Application.DTO.UserDTOs;
using BookLoversProject.Application.Queries.GetUserByIdQuery;
using BookLoversProject.Application.Queries.GetUsersQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookLoversProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UsersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserPutPostDTO user)
        {
            var command = _mapper.Map<CreateUserCommand>(user);

            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { userId = result.Id }, result);
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
        public async Task<IActionResult> GetById(int userId)
        {
            var query = new GetUserByIdQuery { Id = userId };
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPut]
        [Route("{userId}")]
        public async Task<IActionResult> UpdateUser(int userId, [FromBody] UserPutPostDTO updatedUser)
        {
            var command = _mapper.Map<UpdateUserCommand>(updatedUser);
            command.Id = userId;

            var result = await _mediator.Send(command);

            return Ok(result);
        }


        [HttpDelete]
        [Route("{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var command = new DeleteUserCommand { Id = userId };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
