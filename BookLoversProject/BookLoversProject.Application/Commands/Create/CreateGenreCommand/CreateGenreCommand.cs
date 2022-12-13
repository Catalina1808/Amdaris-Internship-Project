using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Create.CreateGenreCommand
{
    public class CreateGenreCommand : IRequest<Genre>
    {
        public string Name { get; set; }
    }
}
