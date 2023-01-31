using BookLoversProject.Application.DTO.BookDTOs;
using MediatR;

namespace BookLoversProject.Application.Commands.Update.AddGenreToBookCommand
{
    public class AddGenreToBookCommand: IRequest<BookGetDTO>
    {
        public int GenreId { get; set; }

        public int BookId { get; set; }
    }
}
