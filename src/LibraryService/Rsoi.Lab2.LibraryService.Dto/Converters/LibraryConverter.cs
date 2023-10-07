using CoreLibrary = Rsoi.Lab2.LibraryService.Core.Models.Library;
using DtoLibrary = Rsoi.Lab2.LibraryService.Dto.Models.Library;

namespace Rsoi.Lab2.LibraryService.Dto.Converters;

public static class LibraryConverter
{
    public static DtoLibrary Convert(CoreLibrary coreLibrary)
    {
        return new DtoLibrary(coreLibrary.Id, coreLibrary.Name, coreLibrary.City, coreLibrary.Address);
    }
}