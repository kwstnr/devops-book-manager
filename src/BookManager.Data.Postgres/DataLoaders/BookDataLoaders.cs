using BookManager.Domain;
using GreenDonut;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Data.Postgres.DataLoaders;

internal static class BookDataLoaders
{
    [DataLoader]
    internal static async Task<IReadOnlyDictionary<Guid, Book>> GetBookByIdAsync(
        IReadOnlyList<Guid> keys,
        BookManagerDbContext context,
        CancellationToken cancellationToken)
        => await context.Books
            .Where(a => keys.Contains(a.Id))
            .ToDictionaryAsync(a => a.Id, cancellationToken);

    [DataLoader]
    internal static async Task<IReadOnlyDictionary<Guid, IEnumerable<Book>>> GetBooksByAuthorIdAsync(
        IReadOnlyList<Guid> authorIds,
        BookManagerDbContext context,
        CancellationToken cancellationToken) =>
        await context.Authors
            .Where(a => authorIds.Contains(a.Id))
            .Select(a => new { Key = a.Id, Books = a.Books.ToList() })
            .ToDictionaryAsync(g => g.Key, g => g.Books.AsEnumerable(), cancellationToken);
}