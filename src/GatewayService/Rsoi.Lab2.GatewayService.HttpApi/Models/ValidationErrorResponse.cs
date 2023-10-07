using System.Runtime.Serialization;
using System.Text;

namespace Rsoi.Lab2.GatewayService.HttpApi.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class ValidationErrorResponse
    {
        /// <summary>
        /// Информация об ошибке
        /// </summary>
        /// <value>Информация об ошибке</value>
        [DataMember(Name="message")]
        public string Message { get; set; }

        /// <summary>
        /// Массив полей с описанием ошибки
        /// </summary>
        /// <value>Массив полей с описанием ошибки</value>
        [DataMember(Name="errors")]
        public List<ErrorDescription> Errors { get; set; }

        public ValidationErrorResponse(string message, 
            List<ErrorDescription> errors)
        {
            Message = message;
            Errors = errors;
        }
    }
}
