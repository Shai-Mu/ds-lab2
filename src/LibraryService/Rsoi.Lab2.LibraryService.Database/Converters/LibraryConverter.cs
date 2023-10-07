using System.Diagnostics.CodeAnalysis;
using Rsoi.Lab2.LibraryService.Database.Converters.EnumConverters;
using DbLibrary = Rsoi.Lab2.LibraryService.Database.Models.Library;
using CoreLibrary = Rsoi.Lab2.LibraryService.Core.Models.Library;

namespace Rsoi.Lab2.LibraryService.Database.Converters;

public class LibraryConverter
{
    [return: NotNullIfNotNull("dbLibrary")]
    public static CoreLibrary? Convert(DbLibrary? dbLibrary)
    {
        if (dbLibrary is null)
            return null;

        return new CoreLibrary(dbLibrary.Id,
            dbLibrary.Name,
            dbLibrary.City,
            dbLibrary.Address);
    }
}