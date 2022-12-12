using BookLoversProject.Application.Interfaces;
using BookLoversProject.Domain.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookLoversProject.Infrastructure.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ApplicationContext _context;

        public AdminRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Admin> AddAdminAsync(Admin admin)
        {
            await _context.Admins.AddAsync(admin);
            return admin;
        }

        public async Task DeleteAdminAsync(int id)
        {
            var admin = await _context.Admins.SingleOrDefaultAsync(x => x.Id == id);
            if(admin == null)
            {
                throw new ArgumentNullException("There is no admin with the given ID.");
            }
            _context.Admins.Remove(admin);
        }

        public async Task<Admin> GetAdminByIdAsync(int id)
        {
            var admin = await _context.Admins.SingleOrDefaultAsync(x => x.Id == id);
            if (admin == null)
            {
                throw new Exception("Exception occured, admin not found!");
            }
            return admin;
        }

        public async Task<ICollection<Admin>> GetAllAdminsAsync()
        {
            return await _context.Admins.ToListAsync();
        }
    }
}
