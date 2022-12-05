using BookLoversProject.Domain.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookLoversProject.Infrastructure.Configurations
{
    public class UserAuthorEntityTypeConfiguration : IEntityTypeConfiguration<UserAuthor>
    {
        public void Configure(EntityTypeBuilder<UserAuthor> userAuthorConfiguration)
        {
            userAuthorConfiguration
                .HasKey(ua => new { ua.UserId, ua.AuthorId });

            userAuthorConfiguration
                .HasOne(ua => ua.User)
                .WithMany(u => u.Authors)
                .HasForeignKey(ua => ua.UserId);

            userAuthorConfiguration
                .HasOne(ua => ua.Author)
                .WithMany(a => a.Followers)
                .HasForeignKey(ua => ua.AuthorId);
        }
    }
}
