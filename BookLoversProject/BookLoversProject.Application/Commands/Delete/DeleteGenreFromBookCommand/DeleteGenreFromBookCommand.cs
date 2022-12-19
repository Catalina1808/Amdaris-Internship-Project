using BookLoversProject.Application.DTO.BookDTOs;
using MediatR;

namespace BookLoversProject.Application.Commands.Delete.DeleteGenreFromBookCommand
{
    public class DeleteGenreFromBookCommand : IRequest<BookGetDTO>
    {
        public int GenreId { get; set; }

        public int BookId { get; set; }
    }
}
