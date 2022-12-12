using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.CreateAuthorCommand
{
    public class CreateAuthorCommand : IRequest<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<int> BooksId { get; set; }
    }
}
