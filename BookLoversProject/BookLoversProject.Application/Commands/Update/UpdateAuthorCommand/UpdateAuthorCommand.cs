using BookLoversProject.Application.DTO;
using MediatR;

namespace BookLoversProject.Application.Commands.Update.UpdateAuthorCommand
{
    public class UpdateAuthorCommand: IRequest<AuthorGetDTO>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
