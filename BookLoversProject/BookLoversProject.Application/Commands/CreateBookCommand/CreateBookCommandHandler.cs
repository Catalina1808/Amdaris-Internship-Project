using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.CreateBookCommand
{
    internal class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateBookCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Title = request.Title,
                Description = request.Description
            };

            var bookAuthorLinks = await GetBookAuthorLinksAsync(request.AuthorsId, book);
            var genreBookLinks = await GetGenreBookLinksAsync(request.GenresId, book);

            book.Authors = bookAuthorLinks;
            book.Genres = genreBookLinks;

            await _unitOfWork.BookRepository.AddBookAsync(book);
            await _unitOfWork.Save();

            return book.Id;
        }

        private async Task<ICollection<BookAuthor>> GetBookAuthorLinksAsync(ICollection<int> authorsId, Book book)
        {
            var bookAuthorLinks = new List<BookAuthor>();
            if (authorsId != null)
            {
                foreach (int id in authorsId)
                {
                    if (await _unitOfWork.AuthorRepository.GetAuthorByIdAsync(id) != null)
                    {
                        bookAuthorLinks.Add(new BookAuthor()
                        {
                            AuthorId = id,
                            Book = book
                        });
                    }
                }
            }
            return bookAuthorLinks;
        }

        private async Task<ICollection<GenreBook>> GetGenreBookLinksAsync(ICollection<int> genresId, Book book)
        {
            var genreBookLinks = new List<GenreBook>();
            if (genresId != null)
            {
                foreach (int id in genresId)
                {
                    if (await _unitOfWork.GenreRepository.GetGenreByIdAsync(id) != null)
                    {
                        genreBookLinks.Add(new GenreBook()
                        {
                            GenreId = id,
                            Book = book
                        });
                    }
                }
            }
            return genreBookLinks;
        }
    }
}
