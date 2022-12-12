using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using MediatR;

namespace BookLoversProject.Application.Commands.CreateAuthorCommand
{
    internal class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateAuthorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = new Author
            {
                Name = request.Name,
                Description = request.Description,
            };

            var bookAuthorLinks = await GetBookAuthorLinksAsync(request.BooksId, author);

            author.Books = bookAuthorLinks;

            await _unitOfWork.AuthorRepository.AddAuthorAsync(author);
            await _unitOfWork.Save();

            return author.Id;
        }

        private async Task<ICollection<BookAuthor>> GetBookAuthorLinksAsync(ICollection<int> booksId, Author author)
        {
            var bookAuthorLinks = new List<BookAuthor>();
            if (booksId != null)
            {
                foreach (int id in booksId)
                {
                    if (await _unitOfWork.BookRepository.GetBookById(id) != null)
                    {
                        bookAuthorLinks.Add(new BookAuthor()
                        {
                            BookId = id,
                            Author = author
                        });
                    }
                }
            }
            return bookAuthorLinks;
        }
    }
}
