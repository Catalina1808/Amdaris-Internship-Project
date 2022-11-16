using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Infrastructure.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private List<Admin> admins;

        public AdminRepository(List<Admin> admins)
        {
            this.admins = admins;
        }

        public Admin AddAdmin(Admin admin)
        {
            admins.Add(admin);
            return admin;
        }

        public void DeleteAdmin(Admin admin)
        {
            admins.Remove(admin);
        }

        public Admin GetAdminById(int id)
        {
            var admin = admins.FirstOrDefault(x => x.Id == id);
            if (admin == null)
            {
                throw new Exception("Exception occured, admin not found!");
            }
            return admin;
        }

        public List<Admin> GetAllAdmins()
        {
            return admins;
        }
    }
}
