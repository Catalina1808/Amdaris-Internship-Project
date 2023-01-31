using AutoMapper;
using BookLoversProject.Application.Commands.Create.CreateReviewCommand;
using BookLoversProject.Application.Commands.Delete.DeleteReviewCommand;
using BookLoversProject.Application.Commands.Update.UpdateReviewCommand;
using BookLoversProject.Application.DTO.ReviewDTOs;
using BookLoversProject.Application.Queries.GetReviewByIdQuery;
using BookLoversProject.Application.Queries.GetReviewsQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookLoversProject.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ReviewController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] ReviewPostDTO review)
        {
            var command = _mapper.Map<CreateReviewCommand>(review);

            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { reviewId = result.Id }, result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetReviewsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("{reviewId}")]
        public async Task<IActionResult> GetById(int reviewId)
        {
            var query = new GetReviewByIdQuery { Id = reviewId };
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPut]
        [Route("{reviewId}")]
        public async Task<IActionResult> UpdateReview(int reviewId, [FromBody] ReviewPutDTO updatedReview)
        {
            var command = _mapper.Map<UpdateReviewCommand>(updatedReview);
            command.Id = reviewId;

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        [Route("{reviewId}")]
        public async Task<IActionResult> DeleteReview(int reviewId)
        {
            var command = new DeleteReviewCommand { Id = reviewId };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
