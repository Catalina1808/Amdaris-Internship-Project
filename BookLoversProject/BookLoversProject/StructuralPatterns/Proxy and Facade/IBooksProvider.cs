using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Presentation.Structural_Patterns.Proxy
{
    public interface IBooksProvider
    {
        public void Initialize();
        public bool IsBookValid(Book book);
        public Task AddBookAsync(IUser user, Book book);
        public Task ListBookByIdAsync(int id);
        public Task ListBooksAsync();
    }
}
