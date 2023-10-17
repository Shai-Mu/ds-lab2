using Rsoi.Lab2.LibraryService.Core.Models;

namespace Rsoi.Lab2.LibraryService.Core.Interfaces;

public interface ILibraryRepository
{
    public Task<Guid> CreateLibraryAsync(string name, string city, string address);

    public Task<List<Library>> GetLibrariesForCity(string city, int? page, int? siz);

    public Task<Library> GetLibraryAsync(Guid id);
}