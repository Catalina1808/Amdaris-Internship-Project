using BookLoversProject.Application.DTO.ShelfDTOs;
using MediatR;

namespace BookLoversProject.Application.Commands.Update.UpdateShelfCommand
{
    public class UpdateShelfCommand: IRequest<ShelfGetDTO>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
