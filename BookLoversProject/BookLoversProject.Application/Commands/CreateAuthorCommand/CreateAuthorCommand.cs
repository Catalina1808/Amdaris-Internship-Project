using MediatR;

namespace BookLoversProject.Application.Commands.CreateAuthorCommand
{
    public class CreateAuthorCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
