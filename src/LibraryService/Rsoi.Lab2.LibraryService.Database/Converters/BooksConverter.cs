using System.Diagnostics.CodeAnalysis;
using Rsoi.Lab2.LibraryService.Database.Converters.EnumConverters;
using DbBooks = Rsoi.Lab2.LibraryService.Database.Models.Books;
using CoreBooks = Rsoi.Lab2.LibraryService.Core.Models.Books;

namespace Rsoi.Lab2.LibraryService.Database.Converters;

public static class BooksConverter
{
    [return: NotNullIfNotNull("dbBooks")]
    public static CoreBooks? Convert(DbBooks? dbBooks)
    {
        if (dbBooks is null)
            return null;

        return new CoreBooks(dbBooks.Id,
            dbBooks.Name,
            dbBooks.Author,
            dbBooks.Genre,
            BookConditionConverter.Convert(dbBooks.Condition));
    }
}