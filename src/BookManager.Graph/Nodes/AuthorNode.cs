using BookManager.Data.Postgres.Abstractions;
using BookManager.Domain;

namespace BookManager.Graph.Nodes;

[ObjectType<Author>]
public static partial class AuthorNode
{
    [NodeResolver]
    public static Task<Author?> GetAuthorByIdAsync(
        Guid id,
        IAuthorService authorService,
        CancellationToken cancellationToken) =>
        authorService.GetAuthorByIdAsync(id, cancellationToken);
    
    public static async Task<IEnumerable<Book>> GetBooksAsync(
        [Parent] Author author,
        IBookService bookService,
        CancellationToken cancellationToken) =>
        await bookService.GetBooksByAuthorIdAsync(author.Id, cancellationToken);
}