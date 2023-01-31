using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Delete.DeleteReviewCommand
{
    public class DeleteReviewCommand: IRequest<Review>
    {
        public int Id { get; set; }
    }
}
