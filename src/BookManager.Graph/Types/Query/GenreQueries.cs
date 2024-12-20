using BookManager.Data.Postgres.Abstractions;
using BookManager.Domain;

namespace BookManager.Graph.Types.Query;

[QueryType]
public static class GenreQueries
{
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public static IQueryable<Genre> GetGenres([Service] IGenreService genreService) => genreService.GetGenres();
}