using BookManager.Data.Postgres.Seeding;
using BookManager.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManager.Data.Postgres.Configurations;

internal class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasData(SeedingData.Authors);
    }
}