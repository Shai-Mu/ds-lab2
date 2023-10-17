using Rsoi.Lab2.GatewayService.HttpApi.Models;
using Rsoi.Lab2.LibraryService.Dto.Models;

namespace Rsoi.Lab2.GatewayService.HttpApi.Converters;

public static class LibraryBookPageConverter
{
   public static LibraryBookPaginationResponse Convert(List<BooksWithCount>? books, decimal? page, decimal? size)
   {
      if (books is null)
         return new LibraryBookPaginationResponse(page, size, 0, new List<LibraryBookResponse>());

      return new LibraryBookPaginationResponse(page, size, books.Count, books.ConvertAll(LibraryBookConverter.Convert));
   }
}