using BookLoversProject.Application.DTO.BookDTOs;
using MediatR;

namespace BookLoversProject.Application.Commands.Create.CreateBookCommand
{
    public class CreateBookCommand : IRequest<BookGetDTO>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public ICollection<int> AuthorsId { get; set; }

        public ICollection<int> GenresId { get; set; }
    }
}
