using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Infrastructure.Repositories
{
    public class AccountAuthorRepository : IAccountAuthorRepository
    {
        private List<AccountAuthor> authors;

        public AccountAuthorRepository(List<AccountAuthor> authors)
        {
            this.authors = authors;
        }

        public AccountAuthor AddAccountAuthor(AccountAuthor accountAuthor)
        {
            authors.Add(accountAuthor);
            return accountAuthor;
        }

        public void AddFollowerToAuthor(User follower, AccountAuthor accountAuthor)
        {
            accountAuthor.Followers.Add(follower);
        }

        public void DeleteAccountAuthor(AccountAuthor accountAuthor)
        {
            authors.Remove(accountAuthor);
        }

        public void DeleteFollowerFromAuthor(User follower, AccountAuthor accountAuthor)
        {
            if (!accountAuthor.Followers.Remove(follower))
            {
                throw new Exception("Follower not found!");
            }
        }

        public AccountAuthor GetAccountAuthorById(int id)
        {
            var author = authors.FirstOrDefault(x => x.Id == id);
            if (author == null)
            {
                throw new Exception("Exception occured, author not found!");
            }
            return author;
        }

        public List<AccountAuthor> GetAllAccountAuthors()
        {
            return authors;
        }
    }
}
