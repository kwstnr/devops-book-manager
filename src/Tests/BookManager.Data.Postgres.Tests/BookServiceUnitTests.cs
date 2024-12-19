// TODO: fix unit tests
// using Moq;
// using BookManager.Data.Postgres.Services;
// using BookManager.Data.Postgres.DataLoaders;
// using BookManager.Domain;
// using Microsoft.EntityFrameworkCore;
//
// namespace BookManager.Data.Postgres.Tests;
//
// [TestFixture]
// public class BookServiceUnitTests
// {
//     private BookManagerDbContext _dbContext;
//     private Mock<IBookByIdDataLoader> _bookByIdDataLoaderMock;
//     private BookService _bookService;
//
//     [SetUp]
//     public void Setup()
//     {
//         var options = new DbContextOptionsBuilder<BookManagerDbContext>()
//             .UseInMemoryDatabase(databaseName: "TestDatabase")
//             .Options;
//
//         _dbContext = new BookManagerDbContext(options);
//         _bookByIdDataLoaderMock = new Mock<IBookByIdDataLoader>();
//         _bookService = new BookService(_dbContext, _bookByIdDataLoaderMock.Object);
//         
//         var books = new List<Book>
//         {
//             new() { Id = Guid.NewGuid(), Title = "Book 1", Description = "Book 1 Description", AuthorId = Guid.NewGuid() },
//             new() { Id = Guid.NewGuid(), Title = "Book 2", Description = "Book 2 Description", AuthorId = Guid.NewGuid() },
//             new() { Id = Guid.NewGuid(), Title = "Book 3", Description = "Book 3 Description", AuthorId = Guid.NewGuid() }
//         };
//
//         _dbContext.Books.AddRange(books);
//         _dbContext.SaveChanges();
//     }
//     
//     [TearDown]
//     public void TearDown()
//     {
//         _dbContext.Database.EnsureDeleted();
//         _dbContext.Dispose();
//     }
//
//     [Test]
//     public void GetBooks_ShouldReturnQueryableBooks()
//     {
//         var result = _bookService.GetBooks();
//         
//         Assert.IsNotNull(result);
//         Assert.That(result.Count(), Is.EqualTo(3));
//     }
//     
//     [Test]
//     public async Task GetBookByIdAsync_ShouldReturnBook_WhenBookExists()
//     {
//         var book = await _dbContext.Books.FirstAsync();
//         _bookByIdDataLoaderMock.Setup(loader => loader.LoadAsync(book.Id, It.IsAny<CancellationToken>()))
//             .ReturnsAsync(book);
//
//         var result = await _bookService.GetBookByIdAsync(book.Id, CancellationToken.None);
//
//         Assert.IsNotNull(result);
//         Assert.That(result?.Id, Is.EqualTo(book.Id));
//         Assert.That(result?.Title, Is.EqualTo(book.Title));
//     }
//     
//     [Test]
//     public async Task GetBookByIdAsync_ShouldReturnNull_WhenBookDoesNotExist()
//     {
//         var nonExistentId = Guid.NewGuid();
//         _bookByIdDataLoaderMock.Setup(loader => loader.LoadAsync(nonExistentId, It.IsAny<CancellationToken>()))
//             .ReturnsAsync((Book?)null);
//
//         var result = await _bookService.GetBookByIdAsync(nonExistentId, CancellationToken.None);
//
//         Assert.IsNull(result);
//     }
// }