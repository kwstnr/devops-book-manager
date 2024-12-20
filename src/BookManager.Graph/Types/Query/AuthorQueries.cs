using BookManager.Data.Postgres.Abstractions;
using BookManager.Domain;

namespace BookManager.Graph.Types.Query;

[QueryType]
public static class AuthorQueries
{
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public static IQueryable<Author> GetAuthors([Service] IAuthorService authorService) => authorService.GetAuthors();
}