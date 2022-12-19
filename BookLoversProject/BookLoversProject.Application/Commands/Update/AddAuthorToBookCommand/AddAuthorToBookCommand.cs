using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Update.AddAuthorToBookCommand
{
    public class AddAuthorToBookCommand: IRequest<Book>
    {
        public int AuthorId { get; set; }

        public int BookId { get; set; }
    }
}
