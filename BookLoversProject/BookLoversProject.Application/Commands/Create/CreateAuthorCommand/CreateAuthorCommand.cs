using BookLoversProject.Application.DTO.AuthorDTOs;
using MediatR;

namespace BookLoversProject.Application.Commands.Create.CreateAuthorCommand
{
    public class CreateAuthorCommand : IRequest<AuthorGetDTO>
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
