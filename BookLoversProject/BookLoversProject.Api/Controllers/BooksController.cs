using AutoMapper;
using BookLoversProject.Application;
using BookLoversProject.Application.Commands.Create.CreateBookCommand;
using BookLoversProject.Application.Commands.Delete.DeleteBookCommand;
using BookLoversProject.Application.Commands.Update.UpdateBookCommand;
using BookLoversProject.Application.DTO;
using BookLoversProject.Application.Exceptions;
using BookLoversProject.Application.Queries.GetBookByIdQuery;
using BookLoversProject.Application.Queries.GetBooksQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BookLoversProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly MySettingsExample _settings;

        private readonly ILogger<BooksController> _logger;

        private readonly IMapper _mapper;

        public BooksController(IMediator mediator, IOptions<MySettingsExample> options, ILogger<BooksController> logger, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
            _settings = options.Value;
            logger.LogInformation(_settings.WelcomeMessage);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetBooksQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("{bookId}")]
        public async Task<IActionResult> GetById(int bookId)
        {
            var query = new GetBookByIdQuery{ Id = bookId };
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPut]
        [Route("{bookId}")]
        public async Task<IActionResult> UpdateBook(int bookId, [FromBody] BookPutDTO updatedBook)
        {

            var command = _mapper.Map<UpdateBookCommand>(updatedBook);
            command.Id = bookId;

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] BookPostDTO book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = _mapper.Map<CreateBookCommand>(book);

            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { bookId = result.Id }, result);
        }

        [HttpDelete]
        [Route("{bookId}")]
        public async Task<IActionResult> DeleteBook(int bookId)
        {
            var command = new DeleteBookCommand { Id = bookId };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
