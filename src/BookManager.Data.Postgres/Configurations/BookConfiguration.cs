using BookManager.Domain;
using BookManager.Data.Postgres.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManager.Data.Postgres.Configurations;

internal class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasOne(x => x.Author)
            .WithMany(x => x.Books)
            .HasForeignKey(x => x.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Genres)
            .WithMany(x => x.Books)
            .UsingEntity<Dictionary<string, object>>(
                "BookGenre",
                j => j.HasOne<Genre>().WithMany().HasForeignKey("GenreId"),
                j => j.HasOne<Book>().WithMany().HasForeignKey("BookId"));
        
        builder.HasData(SeedingData.Books);
    }
}
