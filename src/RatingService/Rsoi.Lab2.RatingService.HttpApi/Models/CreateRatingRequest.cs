using System.Runtime.Serialization;

namespace Rsoi.Lab2.RatingService.HttpApi.Models;

[DataContract]
public class CreateRatingRequest
{
    [DataMember]
    public string Username { get; set; }
    
    [DataMember]
    public int Stars { get; set; }
}