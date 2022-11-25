using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Domain
{
    public class UserFactory
    {

        public static IUser CreateUser(bool isAuthor, string name, string email, string password)
        {
            if (isAuthor)
            {
                return new Author
                {
                    Name = name,
                    Email = email,
                    Password = password
                };
            }
            else
            {
                return new Reader
                {
                    Name = name,
                    Email = email,
                    Password = password
                };
            }
        }
    }
}
