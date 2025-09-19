using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

public class BookServiceTests
{
    private readonly IBookService _bookService;
    private readonly LibraryDbContext _context;

    public BookServiceTests()
    {
        var options = new DbContextOptionsBuilder<LibraryDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

        _context = new LibraryDbContext(options);
        _bookService = new BookService(_context);
    }

    [Fact]
    public async Task CreateAsync_ShouldAddBook()
    {
        var book = new Book { Title = "Test Book", Author = "Author", Description = "Desc" };
        var created = await _bookService.CreateAsync(book);

        created.Should().NotBeNull();
        created.Id.Should().BeGreaterThan(0);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnBooks()
    {
        _context.Books.Add(new Book { Title = "Book1", Author = "Author1", Description = "Desc1" });
        await _context.SaveChangesAsync();

        var books = await _bookService.GetAllAsync();

        books.Should().NotBeEmpty();
    }

    [Fact]
    public async Task UpdateAsync_ShouldModifyBook()
    {
        var book = new Book { Title = "Old Title", Author = "Author", Description = "Desc" };
        await _bookService.CreateAsync(book);

        book.Title = "New Title";
        var result = await _bookService.UpdateAsync(book);

        result.Should().BeTrue();

        var updated = await _bookService.GetByIdAsync(book.Id);
        updated!.Title.Should().Be("New Title");
    }

    [Fact]
    public async Task DeleteAsync_ShouldRemoveBook()
    {
        var book = new Book { Title = "To Delete", Author = "Author", Description = "Desc" };
        await _bookService.CreateAsync(book);

        var result = await _bookService.DeleteAsync(book.Id);

        result.Should().BeTrue();

        var deleted = await _bookService.GetByIdAsync(book.Id);
        deleted.Should().BeNull();
    }
}
