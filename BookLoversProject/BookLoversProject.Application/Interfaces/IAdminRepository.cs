using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Application.Interfaces
{
    public interface IAdminRepository
    {
        Admin AddAdmin(Admin admin);

        Admin GetAdminById(int id);

        List<Admin> GetAllAdmins();

        void DeleteAdmin(Admin admin);
    }
}
