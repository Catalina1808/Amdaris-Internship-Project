using BookLoversProject.Application.DTO.ReviewDTOs;
using MediatR;

namespace BookLoversProject.Application.Commands.Update.UpdateReviewCommand
{
    public class UpdateReviewCommand: IRequest<ReviewGetDTO>
    {
        public int Id { get; set; }

        public string Comment { get; set; }

        public double Rating { get; set; }
    }
}
