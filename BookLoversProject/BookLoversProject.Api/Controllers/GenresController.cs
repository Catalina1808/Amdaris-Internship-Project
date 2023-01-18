using AutoMapper;
using BookLoversProject.Application.Commands.Create.CreateGenreCommand;
using BookLoversProject.Application.Commands.Delete.DeleteGenreCommand;
using BookLoversProject.Application.Commands.Update.UpdateGenreCommand;
using BookLoversProject.Application.DTO.GenreDTOs;
using BookLoversProject.Application.Queries.GetGenreByIdQuery;
using BookLoversProject.Application.Queries.GetGenresQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BookLoversProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public GenresController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateGenre([FromBody] GenrePutPostDTO genre)
        {
            var command = _mapper.Map<CreateGenreCommand>(genre);

            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { genreId = result.Id }, result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetGenreQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("{genreId}")]
        public async Task<IActionResult> GetById(int genreId)
        {
            var query = new GetGenreByIdQuery { Id = genreId };
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPut]
        [Route("{genreId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateGenre(int genreId, [FromBody] GenrePutPostDTO updatedGenre)
        {

            var command = _mapper.Map<UpdateGenreCommand>(updatedGenre);
            command.Id = genreId;

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        [Route("{genreId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteGenre(int genreId)
        {
            var command = new DeleteGenreCommand { Id = genreId };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
