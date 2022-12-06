using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;

namespace BookLoversProject.Infrastructure.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ApplicationContext _context;

        public AdminRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Admin AddAdmin(Admin admin)
        {
            _context.Admins.Add(admin);
            return admin;
        }

        public void DeleteAdmin(int id)
        {
            var admin = _context.Admins.FirstOrDefault(x => x.Id == id);
            if(admin == null)
            {
                throw new ArgumentNullException("There is no admin with the given ID.");
            }
            _context.Admins.Remove(admin);
        }

        public Admin GetAdminById(int id)
        {
            var admin = _context.Admins.FirstOrDefault(x => x.Id == id);
            if (admin == null)
            {
                throw new Exception("Exception occured, admin not found!");
            }
            return admin;
        }

        public ICollection<Admin> GetAllAdmins()
        {
            return _context.Admins.ToList();
        }
    }
}
