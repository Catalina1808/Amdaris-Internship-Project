using BookLoversProject.Domain.Domain;
using BookLoversProject.Presentation.Structural_Patterns.Proxy;

namespace BookLoversProject.Presentation.StructuralPatterns.Proxy
{
    public class BooksProviderProxy : IBooksProvider
    {
        private BooksProvider _booksProvider;

        public BooksProviderProxy()
        {
            _booksProvider= new BooksProvider();
        }

        public Task AddBookAsync(User user, Book book)
        {
            if (user.GetType() == typeof(Admin))
            {
                return _booksProvider.AddBookAsync(user, book);
            }

            throw new Exception("Not authorized!");
        }

        public void Initialize()
        {
           _booksProvider.Initialize();
        }

        public bool IsBookValid(Book book)
        {
            return _booksProvider.IsBookValid(book);
        }

        public Task ListBookByIdAsync(int id)
        {
            return _booksProvider.ListBookByIdAsync(id);
        }

        public Task ListBooksAsync()
        {
            return _booksProvider.ListBooksAsync();
        }
    }
}
