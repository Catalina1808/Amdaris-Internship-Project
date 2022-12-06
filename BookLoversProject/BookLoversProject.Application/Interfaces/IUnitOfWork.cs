namespace BookLoversProject.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IAdminRepository AdminRepository { get; }
        public IAuthorRepository AuthorRepository { get; }
        public IBookRepository BookRepository { get; }
        public IGenreRepository GenreRepository { get; }
        public IReviewRepository ReviewRepository { get; }
        public IShelfRepository ShelfRepository { get; }
        public IUserRepository UserRepository { get; }
        Task Save();
    }
}
