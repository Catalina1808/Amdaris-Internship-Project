using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Domain
{
    public class UserFactory
    {

        public static AbstractUser CreateUser(bool isAdmin, string email, string password)
        {
            if (isAdmin)
            {
                return new Admin
                {
                    Email = email,
                    Password = password
                };
            }
            else
            {
                return new Reader
                {
                    Email = email,
                    Password = password
                };
            }
        }
    }
}
