using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User> AddReader(User user);

        Task<User> GetUserById(int id);

        Task<ICollection<User>> GetAllUsers();

        Task DeleteUser(int id);

        Task AddShelfToUser(Shelf shelf, int userId);

        Task DeleteShelfFromUser(Shelf shelf, int userId);
    }
}
