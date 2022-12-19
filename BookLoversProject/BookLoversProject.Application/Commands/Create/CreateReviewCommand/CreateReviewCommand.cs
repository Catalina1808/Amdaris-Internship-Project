using BookLoversProject.Application.DTO;
using MediatR;

namespace BookLoversProject.Application.Commands.Create.CreateReviewCommand
{
    public class CreateReviewCommand : IRequest<ReviewGetDTO>
    {
        public string Comment { get; set; }
    }
}
