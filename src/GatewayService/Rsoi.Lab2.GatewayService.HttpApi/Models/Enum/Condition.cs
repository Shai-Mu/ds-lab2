using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Rsoi.Lab2.GatewayService.HttpApi.Models.Enum;

/// <summary>
/// Состояние книги
/// </summary>
/// <value>Состояние книги</value>
[JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
public enum Condition
{
            
    /// <summary>
    /// Enum EXCELLENTEnum for EXCELLENT
    /// </summary>
    [EnumMember(Value = "EXCELLENT")]
    Excellent = 1,
            
    /// <summary>
    /// Enum GOODEnum for GOOD
    /// </summary>
    [EnumMember(Value = "GOOD")]
    Good = 2,
            
    /// <summary>
    /// Enum BADEnum for BAD
    /// </summary>
    [EnumMember(Value = "BAD")]
    Bad = 3
}