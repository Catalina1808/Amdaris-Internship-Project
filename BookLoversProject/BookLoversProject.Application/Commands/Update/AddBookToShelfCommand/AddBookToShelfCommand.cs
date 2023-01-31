using BookLoversProject.Application.DTO.ShelfDTOs;
using MediatR;

namespace BookLoversProject.Application.Commands.Update.AddBookToShelfCommand
{
    public class AddBookToShelfCommand : IRequest<ShelfGetDTO>
    {
        public int BookId { get; set; }

        public int ShelfId { get; set; }
    }
}
