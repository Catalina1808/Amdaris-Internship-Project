using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.CreateBookCommand
{
    public class CreateBookCommand: IRequest<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<BookAuthor> AuthorList { get; set; }
        public ICollection<GenreBook> GenreList { get; set; }
    }
}
