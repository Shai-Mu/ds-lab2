using System.Net;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using Rsoi.Lab2.GatewayService.Services.Confiugration;
using Rsoi.Lab2.GatewayService.Services.Exceptions;
using Rsoi.Lab2.RatingService.HttpApi.Models;
using Rsoi.Lab2.ReservationService.Core;
using Rsoi.Lab2.ReservationService.HttpApi.Models;

namespace Rsoi.Lab2.GatewayService.Services.LibraryService;

public class ReservationServiceClient
{
    private readonly RestClient _restClient;

    public ReservationServiceClient(IOptions<ServiceConfiguration> serviceConfiguration)
    {
        var options = new RestClientOptions(serviceConfiguration.Value.ReservationServiceAddress!);
        _restClient = new RestClient(options);        
    }
    
    public async Task<List<Reservation>?> GetReservationsForUserAsync(string username)
    {
        var response = await _restClient.GetAsync(new RestRequest($"user/{username}/reservations"));

        if (response.ResponseStatus is not ResponseStatus.Completed &&
            response.StatusCode is not HttpStatusCode.NotFound)
            throw new InternalServiceException("Reservation service", (int)response.StatusCode,
                response.Content ?? "");

        return JsonConvert.DeserializeObject<List<Reservation>>(response.Content!);
    }

    public async Task<Reservation> CreateReservationAsync(string username, Guid booksId, Guid libraryId, DateTimeOffset tillDate)
    {
        var response = await _restClient
            .PostAsync(new RestRequest("reservations", Method.Post)
            .AddBody(new CreateReservationRequest(username, booksId, libraryId, tillDate)));
            
        if (response.ResponseStatus is not ResponseStatus.Completed &&
            response.StatusCode is not HttpStatusCode.NotFound)
            throw new InternalServiceException("Reservation service", (int)response.StatusCode,
                response.Content ?? "");

        return JsonConvert.DeserializeObject<Reservation>(response.Content!)!;
    }
    
    public async Task<CloseReservationResponse> CloseReservationAsync(Guid reservationId, DateTimeOffset closeDate)
    {
        var query = $"?closeDate={closeDate:O}";
        
        var response = await _restClient
            .PatchAsync(new RestRequest($"reservations/{reservationId}" + query, Method.Patch));
        
        if (response.ResponseStatus is not ResponseStatus.Completed &&
            response.StatusCode is not HttpStatusCode.NotFound)
            throw new InternalServiceException("Reservation service", (int)response.StatusCode,
                response.Content ?? "");

        return JsonConvert.DeserializeObject<CloseReservationResponse>(response.Content!)!;
    }
}