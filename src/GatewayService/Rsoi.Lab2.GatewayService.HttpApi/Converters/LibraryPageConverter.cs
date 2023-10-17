using Rsoi.Lab2.GatewayService.HttpApi.Models;
using Rsoi.Lab2.LibraryService.Dto.Models;

namespace Rsoi.Lab2.GatewayService.HttpApi.Converters;

public static class LibraryPageConverter
{
    public static LibraryPaginationResponse Convert(List<Library>? libraries, decimal? page, decimal? size)
    {
        if (libraries is null)
            return new LibraryPaginationResponse(page, 
                size, 
                0,
                new List<LibraryResponse>());
        
        return new LibraryPaginationResponse(page, 
            size, 
            libraries.Count,
            libraries.ConvertAll(LibraryConverter.Convert));
    }
}