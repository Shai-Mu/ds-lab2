using Microsoft.EntityFrameworkCore;
using Rsoi.Lab2.LibraryService.Core.Interfaces;
using Rsoi.Lab2.LibraryService.Core.Models.Enums;
using Rsoi.Lab2.LibraryService.Database.Converters;
using Rsoi.Lab2.LibraryService.Database.Converters.EnumConverters;
using Rsoi.Lab2.LibraryService.Database.Models;

namespace Rsoi.Lab2.LibraryService.Database.Repositories;

public class BooksRepository : IBooksRepository
{
    private readonly LibraryContext _libraryContext;

    public BooksRepository(LibraryContext libraryContext)
    {
        _libraryContext = libraryContext;
    }

    public async Task<Guid> CreateBooksAsync(Guid id, string name, string genre, string author, BookCondition condition)
    {
        var books = new Books(id, name, author, genre, BookConditionConverter.Convert(condition));

        await _libraryContext.Books.AddAsync(books);

        await _libraryContext.SaveChangesAsync();

        return books.Id;
    }

    public async Task<Core.Models.Books?> FindBooksWithCredentialsAsync(string name, string genre, string author, BookCondition condition)
    {
        var books = await _libraryContext.Books
            .AsNoTracking()
            .FirstOrDefaultAsync(b =>
                b.Author == author 
                && b.Condition == BookConditionConverter.Convert(condition)
                && b.Name == name
                && b.Genre == genre);

        return BooksConverter.Convert(books);
    }

    public async Task<Core.Models.Books> GetBooksAsync(Guid id)
    {
        var book = await _libraryContext.Books
            .AsNoTracking()
            .FirstAsync(b => b.Id == id);

        return BooksConverter.Convert(book);
    }
}