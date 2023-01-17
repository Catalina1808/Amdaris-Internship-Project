using BookLoversProject.Domain.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BookLoversProject.Infrastructure
{
    public class ApplicationContext : IdentityDbContext
    {
        public DbSet<Admin> Admins { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Shelf> Shelves { get; set; }

        public DbSet<User> Users { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(x => x.UserId);
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(x => x.UserId);
            modelBuilder.Entity<IdentityUserToken<string>>().HasKey(x => x.UserId);
        }
    }
}
