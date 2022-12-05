using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Interfaces
{
    public interface IUserRepository
    {
        User AddReader(User user);

        User GetUserById(int id);

        ICollection<User> GetAllUsers();

        void DeleteUser(int id);

        void AddShelfToUser(Shelf shelf, int userId);

        void DeleteShelfFromUser(Shelf shelf, int userId);
    }
}
