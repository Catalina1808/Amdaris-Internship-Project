using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Delete.DeleteGenreCommand
{
    public class DeleteGenreCommand: IRequest<Genre>
    {
        public int Id { get; set; }
    }
}
