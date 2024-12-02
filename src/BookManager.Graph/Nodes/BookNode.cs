using BookManager.Data.Postgres.Abstractions;
using BookManager.Domain;

namespace BookManager.Graph.Nodes;

[ObjectType<Book>]
public static partial class BookNode
{
    static partial void Configure(IObjectTypeDescriptor<Book> descriptor)
    {
        descriptor.Ignore(x => x.AuthorId);
    }
    
    [NodeResolver]
    public static Task<Book?> GetBookByIdAsync(
        Guid id,
        IBookService bookService,
        CancellationToken cancellationToken) =>
        bookService.GetBookByIdAsync(id, cancellationToken);
    
    public static Task<Author?> GetAuthorAsync(
        [Parent] Book book,
        IAuthorService authorService,
        CancellationToken cancellationToken) =>
        authorService.GetAuthorByBookIdAsync(book.Id, cancellationToken);
}