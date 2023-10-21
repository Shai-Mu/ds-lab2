using Microsoft.EntityFrameworkCore;
using Rsoi.Lab2.LibraryService.Core.Interfaces;
using Rsoi.Lab2.LibraryService.Database.Converters;
using Rsoi.Lab2.LibraryService.Database.Models;

namespace Rsoi.Lab2.LibraryService.Database.Repositories;

public class LibraryBooksRepository : ILibraryBooksRepository
{
    private readonly LibraryContext _libraryContext;

    public LibraryBooksRepository(LibraryContext libraryContext)
    {
        _libraryContext = libraryContext;
    }

    public async Task<Guid> CreateLibraryBooksAsync(Guid booksId, Guid libraryId, int count)
    {
        var libraryBooks = new LibraryBooks(Guid.NewGuid(), libraryId, booksId, count);

        _libraryContext.LibraryBooks.Add(libraryBooks);

        await _libraryContext.SaveChangesAsync();

        return libraryBooks.Id;
    }

    public async Task EditLibraryBooksCountAsync(Guid id, int count)
    {
        var libraryBooks = await _libraryContext.LibraryBooks
            .FirstAsync(lb => lb.Id == id);

        libraryBooks.Count = count;

        await _libraryContext.SaveChangesAsync();
    }

    public async Task IncrementLibraryBooksCountAsync(Guid id)
    {
        var libraryBooks = await _libraryContext.LibraryBooks
            .FirstAsync(lb => lb.Id == id);

        libraryBooks.Count++;

        await _libraryContext.SaveChangesAsync();
    }

    public async Task DecrementLibraryBooksCountAsync(Guid id)
    {
        var libraryBooks = await _libraryContext.LibraryBooks
            .FirstAsync(lb => lb.Id == id);

        libraryBooks.Count--;

        await _libraryContext.SaveChangesAsync();    }

    public async Task<Core.Models.LibraryBooks?> FindLibraryBooksByBooksIdAndLibraryIdAsync(Guid booksId, Guid libraryId)
    {
        var libraryBooks = await _libraryContext.LibraryBooks
            .AsNoTracking()
            .FirstOrDefaultAsync(lb => lb.BooksId == booksId 
                              && lb.LibraryId == libraryId);

        return LibraryBooksConverter.Convert(libraryBooks);
    }

    public async Task<List<Core.Models.LibraryBooks>> GetLibraryBooksByLibraryIdAsync(Guid libraryId,
        int? page,
        int? size)
    {
        var librariesBooksQuery = _libraryContext.LibraryBooks
            .AsNoTracking()
            .Where(lb => lb.LibraryId == libraryId);

        if (page is not null && size is not null)
            librariesBooksQuery = librariesBooksQuery
                .Skip((page.Value - 1) * size.Value);
        
        if (size is not null)
            librariesBooksQuery = librariesBooksQuery
                .Take(size.Value);

        var librariesBooks = await librariesBooksQuery
            .ToListAsync();
            

        return librariesBooks.Select(LibraryBooksConverter.Convert).ToList()!;
    }
}