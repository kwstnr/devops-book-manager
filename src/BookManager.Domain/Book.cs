namespace BookManager.Domain;

public class Book
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public int PageCount { get; set; }
    
    public Guid AuthorId { get; set; }
    
    public Author Author { get; set; }
    
    public IEnumerable<Genre> Genres { get; set; }
}