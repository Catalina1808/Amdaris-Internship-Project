using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Delete.DeleteShelfCommand
{
    public class DeleteShelfCommand: IRequest<Shelf>
    {
        public int Id { get; set; }
    }
}
