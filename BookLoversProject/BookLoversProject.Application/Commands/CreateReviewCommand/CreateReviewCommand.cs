using MediatR;

namespace BookLoversProject.Application.Commands.CreateReviewCommand
{
    public class CreateReviewCommand : IRequest <int>
    {
        public string Comment { get; set; }
        public DateTime Date { get; set; }
    }
}
