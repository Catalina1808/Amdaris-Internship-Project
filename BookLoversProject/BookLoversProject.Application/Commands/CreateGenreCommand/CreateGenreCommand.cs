using MediatR;

namespace BookLoversProject.Application.Commands.CreateGenreCommand
{
    public class CreateGenreCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}
