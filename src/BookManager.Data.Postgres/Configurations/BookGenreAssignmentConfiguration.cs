using BookManager.Data.Postgres.Seeding;
using BookManager.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManager.Data.Postgres.Configurations;

internal class BookGenreAssignmentConfiguration : IEntityTypeConfiguration<BookGenreAssignment>
{
    public void Configure(EntityTypeBuilder<BookGenreAssignment> builder)
    {
        builder.HasOne<Book>(x => x.Book)
            .WithMany(x => x.BookGenreAssignments)
            .HasForeignKey(x => x.BookId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<Genre>(x => x.Genre)
            .WithMany(x => x.BookGenreAssignments)
            .HasForeignKey(x => x.GenreId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasData(SeedingData.BookGenreAssignments);
    }
}