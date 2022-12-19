using BookLoversProject.Application.DTO.BookDTOs;
using MediatR;

namespace BookLoversProject.Application.Commands.Delete.DeleteAuthorFromBookCommand
{
    public class DeleteAuthorFromBookCommand: IRequest<BookGetDTO>
    {
        public int AuthorId { get; set; }

        public int BookId { get; set; }
    }
}
