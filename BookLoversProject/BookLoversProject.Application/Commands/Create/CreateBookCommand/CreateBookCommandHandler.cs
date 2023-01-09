using AutoMapper;
using BookLoversProject.Application.DTO.BookDTOs;
using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Create.CreateBookCommand
{
    internal class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, BookGetDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBookCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BookGetDTO> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Title = request.Title,
                Description = request.Description,
                Image = request.Image
            };

            var bookAuthorLinks = await GetBookAuthorLinksAsync(request.AuthorsId, book);
            var genreBookLinks = await GetGenreBookLinksAsync(request.GenresId, book);

            book.Authors = bookAuthorLinks;
            book.Genres = genreBookLinks;


            await _unitOfWork.BookRepository.AddBookAsync(book);
            await _unitOfWork.Save();

            return _mapper.Map<BookGetDTO>(book);
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
