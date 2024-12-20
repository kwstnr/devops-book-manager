namespace BookManager.Domain;

public class Author
{
    public Guid Id { get; set; }
    
    public required string FirstName { get; set; }
    
    public required string LastName { get; set; }
    
    public IEnumerable<Book> Books { get; set; } = new List<Book>();
}
