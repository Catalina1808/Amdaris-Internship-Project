using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User> AddReaderAsync(User user);

        Task<User> GetUserByIdAsync(string id);

        Task<ICollection<User>> GetAllUsersAsync();

        void DeleteUser(User user);

        Task UpdateUserAsync(User user);
    }
}
