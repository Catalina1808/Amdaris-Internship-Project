using BookLoversProject.Application.DTO.ShelfDTOs;
using MediatR;

namespace BookLoversProject.Application.Commands.Delete.DeleteBookFromShelfCommand
{
    public class DeleteBookFromShelfCommand : IRequest<ShelfGetDTO>
    {
        public int BookId { get; set; }

        public int ShelfId { get; set; }
    }
}
