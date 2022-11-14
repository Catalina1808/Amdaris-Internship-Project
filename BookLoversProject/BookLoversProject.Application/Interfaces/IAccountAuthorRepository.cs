using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Interfaces
{
    public interface IAccountAuthorRepository
    {
        AccountAuthor AddAccountAuthor(AccountAuthor accountAuthor);

        AccountAuthor GetAccountAuthorById(int id);

        List<AccountAuthor> GetAllAccountAuthors();

        void DeleteAccountAuthor(AccountAuthor accountAuthor);

        public void AddFollowerToAuthor(User follower, AccountAuthor accountAuthor);

        public void DeleteFollowerFromAuthor(User follower, AccountAuthor accountAuthor);
    }
}
