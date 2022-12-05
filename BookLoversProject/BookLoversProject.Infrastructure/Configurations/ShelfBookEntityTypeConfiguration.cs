using BookLoversProject.Domain.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookLoversProject.Infrastructure.Configurations
{
    public class ShelfBookEntityTypeConfiguration : IEntityTypeConfiguration<ShelfBook>
    {
        public void Configure(EntityTypeBuilder<ShelfBook> shelfBookConfiguration)
        {
            shelfBookConfiguration
                .HasKey(sb => new {sb.ShelfId, sb.BookId});

            shelfBookConfiguration
                .HasOne(sb => sb.Book)
                .WithMany(b => b.Shelves)
                .HasForeignKey(sb => sb.BookId);

            shelfBookConfiguration
                .HasOne(sb => sb.Shelf)
                .WithMany(s => s.Books)
                .HasForeignKey(sb => sb.ShelfId);
        }
    }
}
