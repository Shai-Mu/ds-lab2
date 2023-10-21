using Rsoi.Lab2.LibraryService.Core.Models;
using Rsoi.Lab2.LibraryService.Core.Models.Enums;

namespace Rsoi.Lab2.LibraryService.Core.Interfaces;

public interface IBooksRepository
{
    public Task<Guid> CreateBooksAsync(Guid id, string name, string genre, string author, BookCondition condition);

    public Task<Books?> FindBooksWithCredentialsAsync(string name, string genre, string author, BookCondition condition); 

    public Task<Books> GetBooksAsync(Guid id);
}