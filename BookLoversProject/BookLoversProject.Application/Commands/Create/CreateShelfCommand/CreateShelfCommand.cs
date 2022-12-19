using BookLoversProject.Application.DTO;
using MediatR;

namespace BookLoversProject.Application.Commands.Create.CreateShelfCommand
{
    public class CreateShelfCommand : IRequest<ShelfGetDTO>
    {
        public string Name { get; set; }

        public int UserId { get; set; }
    }
}
