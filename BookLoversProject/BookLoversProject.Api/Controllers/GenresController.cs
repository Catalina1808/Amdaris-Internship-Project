using AutoMapper;
using BookLoversProject.Application.Commands.Create.CreateGenreCommand;
using BookLoversProject.Application.Commands.Delete.DeleteGenreCommand;
using BookLoversProject.Application.Commands.Update.UpdateGenreCommand;
using BookLoversProject.Application.DTO;
using BookLoversProject.Application.Exceptions;
using BookLoversProject.Application.Queries.GetGenreByIdQuery;
using BookLoversProject.Application.Queries.GetGenresQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> CreateGenre([FromBody] GenrePutPostDTO genre)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = _mapper.Map<CreateGenreCommand>(genre);

            var result = await _mediator.Send(command);

            var dto = _mapper.Map<GenreGetDTO>(result);

            return CreatedAtAction(nameof(GetById), new { genreId = dto.Id }, dto);
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
            try
            {
                var result = await _mediator.Send(query);
                return Ok(result);
            }
            catch (ObjectNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("{genreId}")]
        public async Task<IActionResult> UpdateGenre(int genreId, [FromBody] GenrePutPostDTO updatedGenre)
        {

            var command = _mapper.Map<UpdateGenreCommand>(updatedGenre);
            command.Id = genreId;

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete]
        [Route("{genreId}")]
        public async Task<IActionResult> DeleteGenre(int genreId)
        {
            var command = new DeleteGenreCommand { Id = genreId };
            try
            {
                var result = await _mediator.Send(command);
                return NoContent();
            }
            catch (ObjectNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
