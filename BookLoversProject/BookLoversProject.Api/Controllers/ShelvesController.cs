using AutoMapper;
using BookLoversProject.Application.Commands.Create.CreateShelfCommand;
using BookLoversProject.Application.Commands.Delete.DeleteBookFromShelfCommand;
using BookLoversProject.Application.Commands.Delete.DeleteShelfCommand;
using BookLoversProject.Application.Commands.Update.AddBookToShelfCommand;
using BookLoversProject.Application.Commands.Update.UpdateShelfCommand;
using BookLoversProject.Application.DTO.ShelfDTOs;
using BookLoversProject.Application.Queries.GetShelfByIdQuery;
using BookLoversProject.Application.Queries.GetShelvesByUserIdQuery;
using BookLoversProject.Application.Queries.GetShelvesQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookLoversProject.Presentation.Controllers
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
        public async Task<IActionResult> CreateShelf([FromBody] ShelfPostDTO shelf)
        {
            var command = _mapper.Map<CreateShelfCommand>(shelf);

            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { shelfId = result.Id }, result);
        }

        [HttpPost]
        [Route("{shelfId}/Books/{bookId}")]
        public async Task<IActionResult> AddBookToShelf(int shelfId, int bookId)
        {
            var command = new AddBookToShelfCommand
            {
                BookId = bookId,
                ShelfId = shelfId
            };

            var shelf = await _mediator.Send(command);

            return Ok(shelf);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetShelvesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("{shelfId}")]
        public async Task<IActionResult> GetById(int shelfId)
        {
            var query = new GetShelfByIdQuery { Id = shelfId };
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPut]
        [Route("{shelfId}")]
        public async Task<IActionResult> UpdateShelf(int shelfId, [FromBody] ShelfPutDTO updatedShelf)
        {
            var command = _mapper.Map<UpdateShelfCommand>(updatedShelf);
            command.Id = shelfId;

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        [Route("{shelfId}")]
        public async Task<IActionResult> DeleteShelf(int shelfId)
        {
            var command = new DeleteShelfCommand { Id = shelfId };
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete]
        [Route("{shelfId}/Books/{bookId}")]
        public async Task<IActionResult> DeleteBookFromShelf(int shelfId, int bookId)
        {
            var command = new DeleteBookFromShelfCommand
            {
                BookId = bookId,
                ShelfId = shelfId
            };

            var shelf = await _mediator.Send(command);

            return Ok(shelf);
        }
    }
}
