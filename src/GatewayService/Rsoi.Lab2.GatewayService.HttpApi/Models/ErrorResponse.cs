using System.Runtime.Serialization;
using System.Text;

namespace Rsoi.Lab2.GatewayService.HttpApi.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class ErrorResponse
    {
        /// <summary>
        /// Информация об ошибке
        /// </summary>
        /// <value>Информация об ошибке</value>
        [DataMember(Name="message")]
        public string Message { get; set; }

        public ErrorResponse(string message)
        {
            Message = message;
        }
    }
}
