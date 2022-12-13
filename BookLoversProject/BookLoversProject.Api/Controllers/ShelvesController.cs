using AutoMapper;
using BookLoversProject.Application.Commands.Create.CreateGenreCommand;
using BookLoversProject.Application.Commands.Create.CreateShelfCommand;
using BookLoversProject.Application.Commands.Update.AddBookToShelfCommand;
using BookLoversProject.Application.DTO;
using BookLoversProject.Application.Queries.GetGenreByIdQuery;
using BookLoversProject.Application.Queries.GetGenresQuery;
using BookLoversProject.Application.Queries.GetShelfByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookLoversProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShelvesController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ShelvesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateShelf([FromBody] ShelfPutPostDTO shelf)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = _mapper.Map<CreateShelfCommand>(shelf);

            var result = await _mediator.Send(command);

           return CreatedAtAction(nameof(GetById), new { shelfId = result.Id }, result);
        }

        [HttpPost]
        [Route("{shelfId}/books/{bookId}")]
        public async Task<IActionResult> AddBookToShelf(int shelfId, int bookId)
        {
            var command = new AddBookToShelfCommand
            {
                BookId = bookId,
                ShelfId = shelfId
            };

            var shelf = await _mediator.Send(command);

            if (shelf == null)
                return NotFound();

            return Ok(shelf);
        }

        [HttpGet]
        [Route("{shelfId}")]
        public async Task<IActionResult> GetById(int shelfId)
        {
            var query = new GetShelfByIdQuery { Id = shelfId };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
