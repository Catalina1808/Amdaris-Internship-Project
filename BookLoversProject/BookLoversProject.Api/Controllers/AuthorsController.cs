using AutoMapper;
using BookLoversProject.Application.Commands.Create.CreateGenreCommand;
using BookLoversProject.Application.Commands.Update.UpdateAuthorCommand;
using BookLoversProject.Application.DTO;
using BookLoversProject.Application.Queries.GetAuthorByIdQuery;
using BookLoversProject.Application.Queries.GetAuthorsQuery;
using BookLoversProject.Domain.Domain;
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

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut]
        [Route("{authorId}")]
        public async Task<IActionResult> UpdateAuthor(int authorId, [FromBody] AuthorPutPostDTO updatedAuthor)
        {

            var command = _mapper.Map<UpdateAuthorCommand>(updatedAuthor);
            command.Id = authorId;

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return NoContent();
        }
    }
}
