using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Presentation.StructuralPatterns.Proxy
{
    public class BookOperationsFacade
    {
        public void AddBook(User user, Book book)
        {
            var bookProxy = new BooksProviderProxy();
            bookProxy.Initialize();
            if (bookProxy.IsBookValid(book))
            {
                bookProxy.AddBookAsync(user, book);
            }
        }
    }
}
