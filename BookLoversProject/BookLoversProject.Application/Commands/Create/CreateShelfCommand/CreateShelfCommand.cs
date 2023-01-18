using BookLoversProject.Application.DTO.ShelfDTOs;
using MediatR;

namespace BookLoversProject.Application.Commands.Create.CreateShelfCommand
{
    public class CreateShelfCommand : IRequest<ShelfGetDTO>
    {
        public string Name { get; set; }

        public string UserId { get; set; }
    }
}
