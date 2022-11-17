using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Domain
{
    public class AuthorFactory
    {

        public static IAuthor CreateAuthor(bool hasAccount, string name, string email, string password)
        {
            if (hasAccount)
            {
                return new AccountAuthor(name, email, password);
            }
            else
            {
                return new NoAccountAuthor(name);
            }
        }
    }
}
