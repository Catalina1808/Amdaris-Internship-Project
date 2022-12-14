using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Delete.DeleteAuthorCommand
{
    public class DeleteAuthorCommand: IRequest<Author>
    {
        public int Id { get; set; }
    }
}
