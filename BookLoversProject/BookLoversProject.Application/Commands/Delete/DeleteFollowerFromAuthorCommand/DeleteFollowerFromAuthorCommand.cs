using BookLoversProject.Application.DTO.AuthorDTOs;
using MediatR;

namespace BookLoversProject.Application.Commands.Delete.DeleteFollowerFromAuthorCommand
{
    public class DeleteFollowerFromAuthorCommand : IRequest<AuthorGetDTO>
    {
        public string UserId { get; set; }

        public int AuthorId { get; set; }
    }
}
