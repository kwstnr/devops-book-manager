using BookManager.Data.Postgres.Abstractions;
using BookManager.Domain;

namespace BookManager.Graph.Nodes;

[ObjectType<Genre>]
public static partial class GenreNode
{
    static partial void Configure(IObjectTypeDescriptor<Genre> descriptor)
    {
        descriptor.Ignore(x => x.BookGenreAssignments);
    }

    [NodeResolver]
    public static Task<Genre?> GetGenreByIdAsync(
        Guid id,
        IGenreService genreService,
        CancellationToken cancellationToken) =>
        genreService.GetGenreByIdAsync(id, cancellationToken);
}