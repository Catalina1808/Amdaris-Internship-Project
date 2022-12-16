using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Update.UpdateShelfCommand
{
    public class UpdateShelfCommand: IRequest<Shelf>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
