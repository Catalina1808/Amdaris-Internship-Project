using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User> AddReaderAsync(User user);

        Task<User> GetUserByIdAsync(string id);

        Task<ICollection<User>> GetAllUsersAsync(int pageNumber, int pageSize);

        void DeleteUser(User user);

        int GetUsersCount();

        Task UpdateUserAsync(User user);
    }
}
