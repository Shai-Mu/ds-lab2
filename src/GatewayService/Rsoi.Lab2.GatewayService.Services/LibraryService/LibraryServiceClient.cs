using System.Net;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using Rsoi.Lab2.GatewayService.Services.Confiugration;
using Rsoi.Lab2.GatewayService.Services.Exceptions;
using Rsoi.Lab2.LibraryService.Core.Models.Enums;
using Rsoi.Lab2.LibraryService.Dto.Models;

namespace Rsoi.Lab2.GatewayService.Services.LibraryService;

public class LibraryServiceClient : IDisposable
{
    private readonly RestClient _restClient;

    public LibraryServiceClient(IOptions<ServiceConfiguration> serviceConfiguration)
    {
        var options = new RestClientOptions(serviceConfiguration.Value.LibraryServiceAddress!);
        _restClient = new RestClient(options);
    }

    public async Task<List<Library>?> GetCityLibrariesAsync(string city, int? page, int? size)
    {
        var query = $"?city={city}";

        if (page is not null && size is not null)
            query += $"&page={page}&size={size}";
        
        var response = await _restClient.GetAsync(new RestRequest($"libraries" + query));

        if (response.ResponseStatus is not ResponseStatus.Completed &&
            response.StatusCode is not HttpStatusCode.NotFound)
            throw new InternalServiceException("Library service", (int)response.StatusCode,
                response.Content ?? "");

        return JsonConvert.DeserializeObject<List<Library>>(response!.Content!);
    }

    public async Task<List<BooksWithCount>?> GetBooksForLibraryIdAsync(Guid libraryId, int? page, int? size, bool? showAll)
    {
        var query = string.Empty;

        if (page is not null && size is not null)
        {
            query += $"?page={page}&size={size}";
        }

        if (showAll is not null)
        {
            if (!query.Contains('?'))
                query += '?';
            else
                query += '&';

            query += "showAll={showAll}";
        }
        
        var response = await _restClient.GetAsync(new RestRequest($"libraries/{libraryId}/books" + query));
        
        if (response.ResponseStatus is not ResponseStatus.Completed &&
            response.StatusCode is not HttpStatusCode.NotFound)
            throw new InternalServiceException("Library service", (int)response.StatusCode,
                response.Content ?? "");
        
        return JsonConvert.DeserializeObject<List<BooksWithCount>>(response!.Content!);

    }

    public async Task<Books> GetBookAsync(Guid bookId)
    {
        var response = await _restClient.GetAsync(new RestRequest($"books/{bookId}"));
        
        if (response.ResponseStatus is not ResponseStatus.Completed &&
            response.StatusCode is not HttpStatusCode.NotFound)
            throw new InternalServiceException("Library service", (int)response.StatusCode,
                response.Content ?? "");
        
        return JsonConvert.DeserializeObject<Books>(response!.Content!)!;
    }
    
    public async Task<Library> GetLibraryAsync(Guid libraryId)
    {
        var response = await _restClient.GetAsync(new RestRequest($"libraries/{libraryId}"));
        
        if (response.ResponseStatus is not ResponseStatus.Completed &&
            response.StatusCode is not HttpStatusCode.NotFound)
            throw new InternalServiceException("Library service", (int)response.StatusCode,
                response.Content ?? "");
        
        return JsonConvert.DeserializeObject<Library>(response!.Content!)!;
    }

    public async Task TakeBookAsync(Guid bookId, Guid libraryId)
    {
        var response = await _restClient.PatchAsync(new RestRequest($"libraries/{libraryId}/books/{bookId}/decrement", Method.Patch));
        
        if (response.ResponseStatus is not ResponseStatus.Completed &&
            response.StatusCode is not HttpStatusCode.NotFound)
            throw new InternalServiceException("Library service", (int)response.StatusCode,
                response.Content ?? "");
    }

    public async Task ReturnBookAsync(Guid bookId, Guid libraryId, int newState)
    {
        var query = $"?newState={newState}";
        
        var response = await _restClient.PatchAsync(new RestRequest($"libraries/{libraryId}/books/{bookId}/increment" + query, Method.Patch));
        
        if (response.ResponseStatus is not ResponseStatus.Completed &&
            response.StatusCode is not HttpStatusCode.NotFound)
            throw new InternalServiceException("Library service", (int)response.StatusCode,
                response.Content ?? "");
    }

    public void Dispose()
    {
        _restClient.Dispose();
    }
    
}