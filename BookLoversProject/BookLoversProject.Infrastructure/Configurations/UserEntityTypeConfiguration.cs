using BookLoversProject.Domain.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookLoversProject.Infrastructure.Configurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> userAuthorConfiguration)
        {
            userAuthorConfiguration
                .Property(u => u.ImagePath)
                .IsRequired(false);
        }
    }
}
