namespace BookManager.Domain;

public class BookGenreAssignment
{
    public Guid Id { get; set; }
    public Guid BookId { get; set; }
    public Book Book { get; set; }
    public Guid GenreId { get; set; }
    public Genre Genre { get; set; }
}