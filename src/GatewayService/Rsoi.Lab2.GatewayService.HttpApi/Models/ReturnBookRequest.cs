using System.Runtime.Serialization;
using System.Text;
using Rsoi.Lab2.GatewayService.HttpApi.Models.Enum;

namespace Rsoi.Lab2.GatewayService.HttpApi.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class ReturnBookRequest
    {
        /// <summary>
        /// Состояние книги
        /// </summary>
        /// <value>Состояние книги</value>
        [DataMember(Name="condition")]
        public Condition Condition { get; set; }

        /// <summary>
        /// Дата возврата
        /// </summary>
        /// <value>Дата возврата</value>
        [DataMember(Name="date")]
        public string Date { get; set; }

        public ReturnBookRequest(Condition condition, 
            string date)
        {
            Condition = condition;
            Date = date;
        }
    }
}
