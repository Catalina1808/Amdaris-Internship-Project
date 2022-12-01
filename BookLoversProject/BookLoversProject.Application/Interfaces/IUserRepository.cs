using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Interfaces
{
    public interface IUserRepository
    {
        User AddReader(User user);

        User GetUserById(int id);

        List<User> GetAllUsers();

        void DeleteUser(User user);

        void AddShelfToUser(Shelf shelf, int userId);

        void DeleteShelfFromUser(Shelf shelf, int userId);
    }
}
