using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Interfaces
{
    public interface IAdminRepository
    {
        Task<Admin> AddAdmin(Admin admin);

        Task<Admin> GetAdminByIdAsync(int id);

        Task<ICollection<Admin>> GetAllAdminsAsync();

        Task DeleteAdminAsync(int id);
    }
}
