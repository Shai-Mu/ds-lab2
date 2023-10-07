using System.Runtime.Serialization;
using System.Text;

namespace Rsoi.Lab2.GatewayService.HttpApi.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public  class ErrorDescription
    {
        /// <summary>
        /// Gets or Sets Field
        /// </summary>
        [DataMember(Name="field")]
        public string Field { get; set; }

        /// <summary>
        /// Gets or Sets Error
        /// </summary>
        [DataMember(Name="error")]
        public string Error { get; set; }

        public ErrorDescription(string field, string error)
        {
            Field = field;
            Error = error;
        }
    }
}
