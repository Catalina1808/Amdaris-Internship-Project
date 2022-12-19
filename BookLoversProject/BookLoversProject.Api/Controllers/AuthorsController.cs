using AutoMapper;
using BookLoversProject.Application.Commands.Create.CreateAuthorCommand;
using BookLoversProject.Application.Commands.Delete.DeleteAuthorCommand;
using BookLoversProject.Application.Commands.Update.UpdateAuthorCommand;
using BookLoversProject.Application.DTO.AuthorDTOs;
using BookLoversProject.Application.Exceptions;
using BookLoversProject.Application.Queries.GetAuthorByIdQuery;
using BookLoversProject.Application.Queries.GetAuthorsQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookLoversProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AuthorsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] AuthorPutPostDTO author)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = _mapper.Map<CreateAuthorCommand>(author);

            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { authorId = result.Id }, result);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAuthorsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("{authorId}")]
        public async Task<IActionResult> GetById(int authorId)
        {
            var query = new GetAuthorByIdQuery { Id = authorId };
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPut]
        [Route("{authorId}")]
        public async Task<IActionResult> UpdateAuthor(int authorId, [FromBody] AuthorPutPostDTO updatedAuthor)
        {
            var command = _mapper.Map<UpdateAuthorCommand>(updatedAuthor);
            command.Id = authorId;

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        [Route("{authorId}")]
        public async Task<IActionResult> DeleteAuthor(int authorId)
        {
            var command = new DeleteAuthorCommand { Id = authorId };
            
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
