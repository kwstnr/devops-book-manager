using BookManager.Domain;

namespace BookManager.Data.Postgres.Seeding;

internal static class SeedingData
{
    private static Genre SoftwareEngineering => new()
    {
        Id = Guid.Parse("b2d0376b-3e47-461a-8ddf-e830eaf888e8"),
        Name = "Software Engineering"
    };
    
    private static Genre Fiction => new()
    {
        Id = Guid.Parse("eb7f2840-b13e-4c62-ae44-b4d27ad1c251"),
        Name = "Fiction"
    };
    
    private static Author EricEvans => new()
    {
        Id = Guid.Parse("46b198cf-b755-474a-a9f3-7cc48280c29e"),
        FirstName = "Eric",
        LastName = "Evans"
    };
    
    private static Author MarcElsberg => new()
    {
        Id = Guid.Parse("6d8de046-82fa-4a5c-a5c4-5a94c4893b2e"),
        FirstName = "Marc",
        LastName = "Elsberg"
    };
    
    private static Book DomainDrivenDesign => new()
    {
        Id = Guid.Parse("ec7611bb-a7cf-4af3-a81d-1cf231894dff"),
        Title = "Domain-Driven Design",
        Description = "Domain-Driven Design: Tackling Complexity in the Heart of Software is a book by Eric Evans that describes the approach to software development that aligns software design with an organization's business needs.",
        PageCount = 529,
        AuthorId = Guid.Parse("46b198cf-b755-474a-a9f3-7cc48280c29e"),
    };
    
    private static Book Blackout => new()
    {
        Id = Guid.Parse("c5537ac1-76d6-452b-9a45-f6aca18d0e70"),
        Title = "Blackout",
        Description = "Blackout is a techno-thriller novel by Austrian author Marc Elsberg. It was first published in 2012 in German as Blackout: Morgen ist es zu spät. The book deals with an entirely hypothetical blackout of the European electricity grid.",
        PageCount = 416,
        AuthorId = Guid.Parse("6d8de046-82fa-4a5c-a5c4-5a94c4893b2e"),
    };
    
    internal static IEnumerable<Genre> Genres => new List<Genre>
    {
        SoftwareEngineering,
        Fiction
    };

    internal static IEnumerable<Author> Authors => new List<Author>
    {
        EricEvans,
        MarcElsberg
    };

    internal static IEnumerable<Book> Books => new List<Book>
    {
        DomainDrivenDesign,
        Blackout
    };

    internal static IEnumerable<BookGenreAssignment> BookGenreAssignments => new List<BookGenreAssignment>
    {
        new()
        {
            Id = Guid.Parse("a425f7d4-6ec7-4eba-af20-811372cfb361"),
            GenreId = Fiction.Id,
            BookId = Blackout.Id
        },
        new()
        {
            Id = Guid.Parse("0d8539bc-9ae8-402d-a24d-707dce1d7b1b"),
            GenreId = SoftwareEngineering.Id,
            BookId = DomainDrivenDesign.Id
        }
    };
}