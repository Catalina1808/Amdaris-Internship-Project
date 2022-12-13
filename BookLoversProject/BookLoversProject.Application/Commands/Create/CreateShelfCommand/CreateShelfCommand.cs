using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Create.CreateShelfCommand
{
    public class CreateShelfCommand : IRequest<Shelf>
    {
        public string Name { get; set; }

        public int UserId { get; set; }
    }
}
