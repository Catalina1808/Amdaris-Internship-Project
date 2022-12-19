using BookLoversProject.Application.DTO;
using MediatR;

namespace BookLoversProject.Application.Commands.Update.UpdateReviewCommand
{
    public class UpdateReviewCommand: IRequest<ReviewGetDTO>
    {
        public int Id { get; set; }

        public string Comment { get; set; }
    }
}
