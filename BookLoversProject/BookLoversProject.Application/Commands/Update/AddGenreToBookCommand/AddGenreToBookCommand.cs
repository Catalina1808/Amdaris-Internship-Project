using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Update.AddGenreToBookCommand
{
    public class AddGenreToBookCommand: IRequest<Book>
    {
        public int GenreId { get; set; }
        public int BookId { get; set; }
    }
}
