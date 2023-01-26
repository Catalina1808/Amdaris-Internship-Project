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
using BookLoversProject.Application.Queries.GetBooksCount;
using BookLoversProject.Application.Queries.GetBooksCountByGenre;
using BookLoversProject.Application.Queries.GetBooksQuery;
using BookLoversProject.Application.Queries.GetPagedBooksByGenreQuery;
using BookLoversProject.Application.Queries.GetPagedBooksQuery;
using BookLoversProject.Application.Wrappers;
using BookLoversProject.Presentation.Filters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Data;

namespace BookLoversProject.Presentation.Controllers
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
        [Route("Paged")]
        public async Task<IActionResult> GetPagedBooks([FromQuery] PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var query = new GetPagedBooksQuery
            {
                PageNumber = validFilter.PageNumber,
                PageSize = validFilter.PageSize
            };
            var pagedData = await _mediator.Send(query);
            var totalRecords = await _mediator.Send(new GetBooksCountQuery());
            var totalPages = totalRecords / (double)validFilter.PageSize;
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));

            return Ok(new PagedResponse<IEnumerable<BookGetDTO>>(pagedData, validFilter.PageNumber, validFilter.PageSize, roundedTotalPages));
        }

        [HttpGet]
        [Route("PagedByGenre/{genreId}")]
        public async Task<IActionResult> GetPagedBooksByGenre([FromQuery] PaginationFilter filter, int genreId)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var query = new GetPagedBooksByGenreQuery
            {
                PageNumber = validFilter.PageNumber,
                PageSize = validFilter.PageSize,
                GenreId = genreId
            };
            var pagedData = await _mediator.Send(query);
            var totalRecords = await _mediator.Send(new GetBooksCountByGenreQuery { GenreId = genreId});
            var totalPages = (double)totalRecords / (double)validFilter.PageSize;
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));

            return Ok(new PagedResponse<IEnumerable<BookGetDTO>>(pagedData, validFilter.PageNumber, validFilter.PageSize, roundedTotalPages));
        }


        [HttpGet]
        [Route("{bookId}")]
        public async Task<IActionResult> GetById(int bookId)
        {
            var query = new GetBookByIdQuery { Id = bookId };
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
