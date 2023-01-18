using AutoMapper;
using BookLoversProject.Application;
using BookLoversProject.Application.Commands.Create.CreateBookCommand;
using BookLoversProject.Application.Commands.Delete.DeleteAuthorFromBookCommand;
using BookLoversProject.Application.Commands.Delete.DeleteBookCommand;
using BookLoversProject.Application.Commands.Delete.DeleteGenreFromBookCommand;
using BookLoversProject.Application.Commands.Update.AddAuthorToBookCommand;
using BookLoversProject.Application.Commands.Update.AddGenreToBookCommand;
using BookLoversProject.Application.Commands.Update.UpdateBookCommand;
using BookLoversProject.Application.DTO.BookDTOs;
using BookLoversProject.Application.Queries.GetBookByIdQuery;
using BookLoversProject.Application.Queries.GetBooksQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Data;

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

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateBook([FromBody] BookPostDTO book)
        {
            var command = _mapper.Map<CreateBookCommand>(book);

            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { bookId = result.Id }, result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("{bookId}/Authors/{authorId}")]
        public async Task<IActionResult> AddAuthorToBook(int authorId, int bookId)
        {
            var command = new AddAuthorToBookCommand
            {
                BookId = bookId,
                AuthorId = authorId
            };

            var book = await _mediator.Send(command);

            return Ok(book);
        }

        [HttpPost]
        [Route("{bookId}/Genres/{genreId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddGenreToBook(int genreId, int bookId)
        {
            var command = new AddGenreToBookCommand
            {
                BookId = bookId,
                GenreId = genreId
            };

            var book = await _mediator.Send(command);

            return Ok(book);
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateBook(int bookId, [FromBody] BookPutDTO updatedBook)
        {

            var command = _mapper.Map<UpdateBookCommand>(updatedBook);
            command.Id = bookId;

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        [Route("{bookId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteBook(int bookId)
        {
            var command = new DeleteBookCommand { Id = bookId };
            await _mediator.Send(command);

            return NoContent();
        }


        [HttpDelete]
        [Route("{bookId}/Authors/{authorId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAuthorToFromBook(int authorId, int bookId)
        {
            var command = new DeleteAuthorFromBookCommand
            {
                BookId = bookId,
                AuthorId = authorId
            };

            var book = await _mediator.Send(command);

            return Ok(book);
        }

        [HttpDelete]
        [Route("{bookId}/Genres/{genreId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteGenreFromBook(int genreId, int bookId)
        {
            var command = new DeleteGenreFromBookCommand
            {
                BookId = bookId,
                GenreId = genreId
            };

            var book = await _mediator.Send(command);

            return Ok(book);
        }
    }
}
