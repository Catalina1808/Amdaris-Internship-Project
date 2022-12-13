using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Create.CreateAuthorCommand
{
    public class CreateAuthorCommand : IRequest<Author>
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
