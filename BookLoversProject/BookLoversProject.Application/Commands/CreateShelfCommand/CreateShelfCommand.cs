using MediatR;

namespace BookLoversProject.Application.Commands.CreateShelfCommand
{
    public class CreateShelfCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}
