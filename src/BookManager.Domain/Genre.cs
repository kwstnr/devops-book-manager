namespace BookManager.Domain;

public class Genre
{
    public Guid Id { get; set; }
    
    public required string Name { get; set; }
    
    public IEnumerable<Book> Books { get; set; } = new List<Book>();
}
