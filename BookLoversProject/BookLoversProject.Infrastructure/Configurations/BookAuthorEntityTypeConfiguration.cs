using BookLoversProject.Domain.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookLoversProject.Infrastructure.Configurations
{
    public class BookAuthorEntityTypeConfiguration : IEntityTypeConfiguration<BookAuthor>
    {
        public void Configure(EntityTypeBuilder<BookAuthor> bookAuthorConfiguration)
        {
            bookAuthorConfiguration
                .HasKey(ba => new { ba.BookId, ba.AuthorId });

            bookAuthorConfiguration
                .HasOne(ba => ba.Book)
                .WithMany(b => b.Authors)
                .HasForeignKey(ba => ba.BookId);

            bookAuthorConfiguration
                .HasOne(ba => ba.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(ba => ba.AuthorId);
        }
    }
}
