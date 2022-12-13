using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Update.AddBookToShelfCommand
{
    public class AddBookToShelfCommand: IRequest<Shelf>
    {
        public int BookId { get; set; }

        public int ShelfId { get; set; }
    }
}
