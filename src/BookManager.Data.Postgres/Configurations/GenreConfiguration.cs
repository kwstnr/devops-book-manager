using BookManager.Data.Postgres.Seeding;
using BookManager.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManager.Data.Postgres.Configurations;

internal class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.HasMany(x => x.Books)
            .WithMany(x => x.Genres)
            .UsingEntity<Dictionary<string, object>>(
                "BookGenre",
                j => j.HasOne<Book>().WithMany().HasForeignKey("BookId"),
                j => j.HasOne<Genre>().WithMany().HasForeignKey("GenreId"));
        
        builder.HasData(SeedingData.Genres);
    }
}