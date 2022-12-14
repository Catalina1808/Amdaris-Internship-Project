using AutoMapper;
using BookLoversProject.Application.Commands.Create.CreateShelfCommand;
using BookLoversProject.Application.Commands.Delete.DeleteShelfCommand;
using BookLoversProject.Application.Commands.Update.AddBookToShelfCommand;
using BookLoversProject.Application.DTO;
using BookLoversProject.Application.Exceptions;
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

            var dto = _mapper.Map<ShelfGetDTO>(result);

            return CreatedAtAction(nameof(GetById), new { shelfId = dto.Id }, dto);
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

            try
            {
                var shelf = await _mediator.Send(command);
                return Ok(_mapper.Map<ShelfGetDTO>(shelf));
            }
            catch (ObjectNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("{shelfId}")]
        public async Task<IActionResult> GetById(int shelfId)
        {
            var query = new GetShelfByIdQuery { Id = shelfId };
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

        [HttpDelete]
        [Route("{shelfId}")]
        public async Task<IActionResult> DeleteShelf(int shelfId)
        {
            var command = new DeleteShelfCommand { Id = shelfId };
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
