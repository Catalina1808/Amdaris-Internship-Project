using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Delete.DeleteUserCommand
{
    public class DeleteUserCommand: IRequest<User>
    {
        public string Id { get; set; }
    }
}
