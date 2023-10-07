using System.Diagnostics.CodeAnalysis;
using DbLibraryBooks = Rsoi.Lab2.LibraryService.Database.Models.LibraryBooks;
using CoreLibraryBooks = Rsoi.Lab2.LibraryService.Core.Models.LibraryBooks;

namespace Rsoi.Lab2.LibraryService.Database.Converters;

public static class LibraryBooksConverter
{
    
    [return: NotNullIfNotNull("dbLibraryBooks")]
    public static CoreLibraryBooks? Convert(DbLibraryBooks? dbLibraryBooks)
    {
        if (dbLibraryBooks is null)
            return null;

        return new CoreLibraryBooks(dbLibraryBooks.Id, dbLibraryBooks.LibraryId, dbLibraryBooks.BooksId,
            dbLibraryBooks.Count);
    }
}