using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Presentation.Structural_Patterns.Proxy
{
    public interface IBooksProvider
    {
        public Task AddBookAsync(User user, Book book);
        public Task ListBookByIdAsync(int id);
        public Task ListBooksAsync();
    }
}
