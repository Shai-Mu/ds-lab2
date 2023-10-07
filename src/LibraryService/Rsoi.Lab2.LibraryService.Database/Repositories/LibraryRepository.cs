﻿using Microsoft.EntityFrameworkCore;
using Rsoi.Lab2.LibraryService.Core.Interfaces;
using Rsoi.Lab2.LibraryService.Database.Converters;
using Rsoi.Lab2.LibraryService.Database.Models;

namespace Rsoi.Lab2.LibraryService.Database.Repositories;

public class LibraryRepository : ILibraryRepository
{
    private readonly LibraryContext _libraryContext;

    public LibraryRepository(LibraryContext libraryContext)
    {
        _libraryContext = libraryContext;
    }

    public async Task<Guid> CreateLibraryAsync(string name, string city, string address)
    {
        var library = new Library(Guid.NewGuid(),
            name, 
            city,
            address);

        await _libraryContext.Libraries.AddAsync(library);

        await _libraryContext.SaveChangesAsync();
        
        return library.Id;
    }

    public async Task<List<Core.Models.Library>> GetLibrariesForCity(string city)
    {
        var libraries = await _libraryContext.Libraries
            .AsNoTracking()
            .Where(l => l.City == city)
            .ToListAsync();

        return libraries.Select(LibraryConverter.Convert).ToList()!;
    }

    public async Task<Core.Models.Library> GetLibraryAsync(Guid id)
    {
        var libraries = await _libraryContext.Libraries
            .AsNoTracking()
            .FirstAsync(l => l.Id == id);

        return LibraryConverter.Convert(libraries);
    }
}