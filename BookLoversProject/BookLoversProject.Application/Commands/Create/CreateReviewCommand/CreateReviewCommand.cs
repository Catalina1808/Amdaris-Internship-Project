using BookLoversProject.Application.DTO.ReviewDTOs;
using MediatR;

namespace BookLoversProject.Application.Commands.Create.CreateReviewCommand
{
    public class CreateReviewCommand : IRequest<ReviewGetDTO>
    {
        public string Comment { get; set; }

        public int BookId { get; set; }

        public int UserId { get; set; }
    }
}
