using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Delete.DeleteBookCommand
{
    public class DeleteBookCommand: IRequest<Book>
    {
        public int Id { get; set; }
    }
}
