using System.Runtime.Serialization;
using Newtonsoft.Json;
using Rsoi.Lab2.RatingService.Core;

namespace Rsoi.Lab2.RatingService.HttpApi.Models;

[DataContract]
public class RatingResponse
{
    public RatingResponse(Rating? rating)
    {
        Rating = rating;
    }

    [DataMember]
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public Rating? Rating { get; set; }
    
}