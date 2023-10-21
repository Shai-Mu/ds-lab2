using System.Net;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using Rsoi.Lab2.GatewayService.Services.Confiugration;
using Rsoi.Lab2.GatewayService.Services.Exceptions;
using Rsoi.Lab2.RatingService.Dto.Models;

namespace Rsoi.Lab2.GatewayService.Services.LibraryService;

public class RatingServiceClient
{
    private readonly RestClient _restClient;

    public RatingServiceClient(IOptions<ServiceConfiguration> serviceConfiguration)
    {
        var options = new RestClientOptions(serviceConfiguration.Value.RatingServiceAddress!);
        _restClient = new RestClient(options);        
    }
    
    public async Task<RatingResponse?> GetRatingForUserAsync(string username)
    {
        var query = $"?username={username}";

        var response = await _restClient.GetAsync(new RestRequest($"ratings" + query));

        if (response.ResponseStatus is not ResponseStatus.Completed &&
            response.StatusCode is not HttpStatusCode.NotFound)
            throw new InternalServiceException("Rating service", (int)response.StatusCode,
                response.Content ?? "");

        return JsonConvert.DeserializeObject<RatingResponse>(response!.Content!);
    }

    public async Task EditRatingForUserAsync(Guid ratingId, int ratingValue)
    {
        var query = $"?stars={ratingValue}";
        
        var response = await _restClient.PatchAsync(new RestRequest($"ratings/{ratingId}" + query, Method.Patch));

        if (response.ResponseStatus is not ResponseStatus.Completed &&
            response.StatusCode is not HttpStatusCode.NotFound)
            throw new InternalServiceException("Rating service", (int)response.StatusCode,
                response.Content ?? "");
    }
}