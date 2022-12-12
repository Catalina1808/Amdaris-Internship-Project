using AutoMapper;
using BookLoversProject.Application.Commands.CreateGenreCommand;
using BookLoversProject.Application.DTO;
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

            int id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { genreId = id }, genre);
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

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
