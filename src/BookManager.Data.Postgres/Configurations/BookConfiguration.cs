using BookManager.Domain;
using BookManager.Data.Postgres.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManager.Data.Postgres.Configurations;

internal class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasOne<Author>(x => x.Author)
            .WithMany(x => x.Books)
            .HasForeignKey(x => x.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasData(SeedingData.Books);
    }
}