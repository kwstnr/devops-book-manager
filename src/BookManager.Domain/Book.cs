namespace BookManager.Domain;

public class Book
{
    public Guid Id { get; set; }
    
    public required string Title { get; set; }
    
    public required string Description { get; set; }
    
    public int PageCount { get; set; }
    
    public Guid AuthorId { get; set; }
    
    public Author Author { get; set; } = null!;
    
    public IEnumerable<Genre> Genres { get; set; } = new List<Genre>();
}
