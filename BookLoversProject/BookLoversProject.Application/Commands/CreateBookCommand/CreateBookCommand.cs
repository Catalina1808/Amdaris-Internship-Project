using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.CreateBookCommand
{
    public class CreateBookCommand: IRequest<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<IAuthor> AuthorList { get; set; }
        public List<Genre> GenreList { get; set; }
    }
}
