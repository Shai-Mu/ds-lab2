using Rsoi.Lab2.GatewayService.HttpApi.Models;
using Rsoi.Lab2.LibraryService.Dto.Models;

namespace Rsoi.Lab2.GatewayService.HttpApi.Converters;

public static class LibraryBookConverter
{
    public static LibraryBookResponse Convert(BooksWithCount booksWithCount)
    {
        return new LibraryBookResponse(booksWithCount.Id, 
            booksWithCount.Name, 
            booksWithCount.Author,
            booksWithCount.Genre, 
            BookConditionConverter.Convert(booksWithCount.Condition), 
            booksWithCount.Count);
    }

    public static BookInfo Convert(Books books)
    {
        return new BookInfo(books.Id, books.Name, books.Author, books.Genre);
    }
}