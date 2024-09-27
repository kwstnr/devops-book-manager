using BookManager.Data.Postgres.Abstractions;
using BookManager.Domain;

namespace BookManager.Graph.Types.Query;

[QueryType]
public static class BookQueries
{
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public static IQueryable<Book> GetBooks([Service] IBookService bookService) => bookService.GetBooks();
}