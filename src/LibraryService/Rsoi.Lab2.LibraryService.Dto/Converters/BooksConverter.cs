using Rsoi.Lab2.LibraryService.Dto.Models;
using CoreBooks = Rsoi.Lab2.LibraryService.Core.Models.Books;
using DtoBooks = Rsoi.Lab2.LibraryService.Dto.Models.Books;

namespace Rsoi.Lab2.LibraryService.Dto.Converters;

public static class BooksConverter
{
    public static BooksWithCount ConvertWithCount(CoreBooks coreBooks, int count)
    {
        return new BooksWithCount(coreBooks.Id, 
            coreBooks.Name, 
            coreBooks.Author, 
            coreBooks.Genre, 
            coreBooks.Condition,
            count);
    }
    
    public static Books Convert(CoreBooks coreBooks)
    {
        return new DtoBooks(coreBooks.Id, 
            coreBooks.Name, 
            coreBooks.Author, 
            coreBooks.Genre, 
            coreBooks.Condition);
    }
}