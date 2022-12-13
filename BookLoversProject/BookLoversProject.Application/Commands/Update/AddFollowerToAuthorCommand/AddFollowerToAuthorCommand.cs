using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Update.AddFollowerToAuthorCommand
{
    public class AddFollowerToAuthorCommand: IRequest<Author>
    {
        public int UserId { get; set; }
        public int AuthorId { get; set; }
    }
}
