using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.CreateAuthorCommand
{
    public class CreateAuthorCommand : IRequest<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<BookAuthor> Books { get; set; }

        public ICollection<UserAuthor> Followers { get; set; }
    }
}
