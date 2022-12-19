using AutoMapper;
using BookLoversProject.Application.Commands.Create.CreateAdminCommand;
using BookLoversProject.Application.Commands.Delete.DeleteAdminCommand;
using BookLoversProject.Application.Commands.Update.UpdateAdminCommand;
using BookLoversProject.Application.DTO;
using BookLoversProject.Application.Exceptions;
using BookLoversProject.Application.Queries.GetAdminByIdQuery;
using BookLoversProject.Application.Queries.GetAdminsQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookLoversProject.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AdminController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<IActionResult> CreateAdmin([FromBody] AdminPutPostDTO admin)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = _mapper.Map<CreateAdminCommand>(admin);

            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { adminId = result.Id }, result);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAdminsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("{adminId}")]
        public async Task<IActionResult> GetById(int adminId)
        {
            var query = new GetAdminByIdQuery { Id = adminId };
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPut]
        [Route("{adminId}")]
        public async Task<IActionResult> UpdateAdmin(int adminId, [FromBody] AdminPutPostDTO updatedAdmin)
        {
            var command = _mapper.Map<UpdateAdminCommand>(updatedAdmin);
            command.Id = adminId;

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        [Route("{adminId}")]
        public async Task<IActionResult> DeleteAdmin(int adminId)
        {
            var command = new DeleteAdminCommand { Id = adminId };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
