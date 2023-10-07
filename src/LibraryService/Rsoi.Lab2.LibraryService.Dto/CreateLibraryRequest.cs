using System.Runtime.Serialization;
using Rsoi.Lab2.LibraryService.Dto.Models;

namespace Rsoi.Lab2.LibraryService.Dto;

[DataContract]
public class CreateLibraryRequest
{
    [DataMember] 
    public List<Library> Libraries { get; set; }
    
    public CreateLibraryRequest(List<Library> libraries)
    {
        Libraries = libraries;
    }
}