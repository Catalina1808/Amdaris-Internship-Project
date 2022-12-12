using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User> AddReaderAsync(User user);

        Task<User> GetUserByIdAsync(int id);

        Task<ICollection<User>> GetAllUsersAsync();

        Task DeleteUserAsync(int id);

        Task AddShelfToUserAsync(Shelf shelf, int userId);

        Task DeleteShelfFromUserAsync(Shelf shelf, int userId);
    }
}
