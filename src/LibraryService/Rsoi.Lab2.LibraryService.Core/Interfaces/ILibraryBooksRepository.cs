using Rsoi.Lab2.LibraryService.Core.Models;

namespace Rsoi.Lab2.LibraryService.Core.Interfaces;

public interface ILibraryBooksRepository
{
    public Task<Guid> CreateLibraryBooksAsync(Guid booksId, Guid libraryId, int count);

    public Task EditLibraryBooksCountAsync(Guid id, int count);

    public Task IncrementLibraryBooksCountAsync(Guid id);
    
    public Task DecrementLibraryBooksCountAsync(Guid id);

    public Task<LibraryBooks?> FindLibraryBooksByBooksIdAndLibraryIdAsync(Guid booksId, Guid libraryId);

    public Task<List<LibraryBooks>> GetLibraryBooksByLibraryIdAsync(Guid libraryId, int? take, int? skip);
}