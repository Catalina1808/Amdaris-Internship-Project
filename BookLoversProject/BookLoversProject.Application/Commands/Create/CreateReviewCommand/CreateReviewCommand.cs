using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Create.CreateReviewCommand
{
    public class CreateReviewCommand : IRequest<Review>
    {
        public string Comment { get; set; }
        public DateTime Date { get; set; }
    }
}
