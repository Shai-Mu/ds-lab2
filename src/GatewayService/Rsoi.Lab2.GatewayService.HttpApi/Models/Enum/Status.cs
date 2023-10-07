using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Rsoi.Lab2.GatewayService.HttpApi.Models.Enum;

/// <summary>
/// Статус бронирования книги
/// </summary>
/// <value>Статус бронирования книги</value>
[JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public enum Status
{
        
    /// <summary>
    /// Enum RENTEDEnum for RENTED
    /// </summary>
    [EnumMember(Value = "RENTED")]
    Rented = 1,
        
    /// <summary>
    /// Enum RETURNEDEnum for RETURNED
    /// </summary>
    [EnumMember(Value = "RETURNED")]
    Returned = 2,
        
    /// <summary>
    /// Enum EXPIREDEnum for EXPIRED
    /// </summary>
    [EnumMember(Value = "EXPIRED")]
    Expired = 3
}