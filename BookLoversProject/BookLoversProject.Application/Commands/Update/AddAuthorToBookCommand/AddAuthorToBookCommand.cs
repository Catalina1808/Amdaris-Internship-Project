using BookLoversProject.Application.DTO.BookDTOs;
using MediatR;

namespace BookLoversProject.Application.Commands.Update.AddAuthorToBookCommand
{
    public class AddAuthorToBookCommand: IRequest<BookGetDTO>
    {
        public int AuthorId { get; set; }

        public int BookId { get; set; }
    }
}
