using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Update.UpdateGenreCommand
{
    public class UpdateGenreCommand: IRequest<Genre>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
