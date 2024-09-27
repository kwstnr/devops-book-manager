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
}