using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Update.UpdateReviewCommand
{
    public class UpdateReviewCommand: IRequest<Review>
    {
        public int Id { get; set; }

        public string Comment { get; set; }
    }
}
