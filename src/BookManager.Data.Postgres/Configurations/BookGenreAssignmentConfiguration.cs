using BookManager.Data.Postgres.Seeding;
using BookManager.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManager.Data.Postgres.Configurations;

internal class BookGenreAssignmentConfiguration : IEntityTypeConfiguration<BookGenreAssignment>
{
    public void Configure(EntityTypeBuilder<BookGenreAssignment> builder)
    {
        builder.HasData(SeedingData.BookGenreAssignments);
    }
}