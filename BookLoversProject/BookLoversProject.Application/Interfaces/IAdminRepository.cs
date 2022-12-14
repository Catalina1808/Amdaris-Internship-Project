using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Interfaces
{
    public interface IAdminRepository
    {
        Task<Admin> AddAdminAsync(Admin admin);

        Task<Admin> GetAdminByIdAsync(int id);

        Task<ICollection<Admin>> GetAllAdminsAsync();

        void DeleteAdmin(Admin admin);

        void UpdateAdmin(Admin admin);
    }
}
