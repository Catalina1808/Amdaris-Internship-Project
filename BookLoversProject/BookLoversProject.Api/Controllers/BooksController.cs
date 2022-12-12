using BookLoversProject.Application;
using BookLoversProject.Application.Queries.GetBookByIdQuery;
using BookLoversProject.Application.Queries.GetBooksQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BookLoversProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly MySettingsExample _settings;

        private readonly ILogger<BooksController> _logger;

        public BooksController(IMediator mediator, IOptions<MySettingsExample> options, ILogger<BooksController> logger)
        {
            _mediator = mediator;
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

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
