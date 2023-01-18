using BookLoversProject.Application.Interfaces;

namespace BookLoversProject.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _applicationContext;

        public UnitOfWork(ApplicationContext applicationContext, IAuthorRepository authorRepository,
            IBookRepository bookRepository, IGenreRepository genreRepository, IReviewRepository reviewRepository,
            IShelfRepository shelfRepository, IUserRepository userRepository)
        {
            _applicationContext = applicationContext;
            AuthorRepository = authorRepository;
            BookRepository = bookRepository;
            GenreRepository = genreRepository;
            ReviewRepository = reviewRepository;
            ShelfRepository = shelfRepository;
            UserRepository = userRepository;
        }

        public IAuthorRepository AuthorRepository { get; private set; }

        public IBookRepository BookRepository { get; private set; }

        public IGenreRepository GenreRepository { get; private set; }

        public IReviewRepository ReviewRepository { get; private set; }

        public IShelfRepository ShelfRepository { get; private set; }

        public IUserRepository UserRepository { get; private set; }

        public void Dispose()
        {
            _applicationContext.Dispose();
        }

        public async Task Save()
        {
           await _applicationContext.SaveChangesAsync();
        }
    }
}
