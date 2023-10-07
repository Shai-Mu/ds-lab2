using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Rsoi.Lab2.GatewayService.HttpApi.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class UserRatingResponse
    {
        /// <summary>
        /// Количество здесь у пользователя
        /// </summary>
        /// <value>Количество здесь у пользователя</value>
        [Range(0, 100)]
        [DataMember(Name="stars")]
        public decimal Stars { get; set; }

        public UserRatingResponse(decimal stars)
        {
            Stars = stars;
        }
    }
}
