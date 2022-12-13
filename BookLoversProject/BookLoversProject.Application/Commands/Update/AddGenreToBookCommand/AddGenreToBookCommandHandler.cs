using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.Update.AddGenreToBookCommand
{
    public class AddGenreToBookCommandHandler : IRequestHandler<AddGenreToBookCommand, Book>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddGenreToBookCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Book> Handle(AddGenreToBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.BookRepository.GetBookByIdAsync(request.BookId);
            var genre = await _unitOfWork.GenreRepository.GetGenreByIdAsync(request.GenreId);

            if(book == null || genre == null)
            {
                return null;
            }

            var genreBookLink = new GenreBook { BookId = request.BookId, GenreId = request.GenreId };

            book.Genres.Add(genreBookLink);
            await _unitOfWork.Save();

            return book;
        }
    }
}
