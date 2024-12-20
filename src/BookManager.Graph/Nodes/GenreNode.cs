using BookManager.Data.Postgres.Abstractions;
using BookManager.Domain;

namespace BookManager.Graph.Nodes;

[ObjectType<Genre>]
public static partial class GenreNode
{
    [NodeResolver]
    public static Task<Genre?> GetGenreByIdAsync(
        Guid id,
        IGenreService genreService,
        CancellationToken cancellationToken) =>
        genreService.GetGenreByIdAsync(id, cancellationToken);
    
    public static Task<IEnumerable<Book>> GetBooksAsync(
        [Parent] Genre genre,
        IBookService bookService,
        CancellationToken cancellationToken) =>
        bookService.GetBooksByGenreIdAsync(genre.Id, cancellationToken);
}