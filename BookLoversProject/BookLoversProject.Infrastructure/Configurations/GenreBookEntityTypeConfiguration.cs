using BookLoversProject.Domain.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookLoversProject.Infrastructure.Configurations
{
    public class GenreBookEntityTypeConfiguration : IEntityTypeConfiguration<GenreBook>
    {
        public void Configure(EntityTypeBuilder<GenreBook> genreBookConfiguration)
        {
            genreBookConfiguration
                .HasKey(gb => new { gb.GenreId, gb.BookId });

            genreBookConfiguration
                .HasOne(ba => ba.Book)
                .WithMany(b => b.Genres)
                .HasForeignKey(ba => ba.BookId);

            genreBookConfiguration
                .HasOne(gb => gb.Genre)
                .WithMany(g => g.Books)
                .HasForeignKey(gb => gb.GenreId);
        }
    }
}
