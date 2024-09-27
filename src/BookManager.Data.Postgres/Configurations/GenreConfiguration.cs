using BookManager.Data.Postgres.Seeding;
using BookManager.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManager.Data.Postgres.Configurations;

internal class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.HasData(SeedingData.Genres);
    }
}