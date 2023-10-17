using Rsoi.Lab2.GatewayService.HttpApi.Models;
using Rsoi.Lab2.LibraryService.Dto.Models;

namespace Rsoi.Lab2.GatewayService.HttpApi.Converters;

public static class LibraryConverter
{
    public static LibraryResponse Convert(Library libraryServiceLibrary)
    {
        return new LibraryResponse(libraryServiceLibrary.Id, 
            libraryServiceLibrary.Name, 
            libraryServiceLibrary.Address,
            libraryServiceLibrary.City);
    }
}