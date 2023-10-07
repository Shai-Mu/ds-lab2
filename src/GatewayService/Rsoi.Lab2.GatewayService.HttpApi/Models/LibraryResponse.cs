using System.Runtime.Serialization;
using System.Text;

namespace Rsoi.Lab2.GatewayService.HttpApi.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class LibraryResponse 
    {
        /// <summary>
        /// UUID библиотеки
        /// </summary>
        /// <value>UUID библиотеки</value>
        [DataMember(Name="libraryUid")]
        public Guid LibraryUid { get; set; }

        /// <summary>
        /// Название библиотеки
        /// </summary>
        /// <value>Название библиотеки</value>
        [DataMember(Name="name")]
        public string Name { get; set; }

        /// <summary>
        /// Адрес библиотеки
        /// </summary>
        /// <value>Адрес библиотеки</value>
        [DataMember(Name="address")]
        public string Address { get; set; }

        /// <summary>
        /// Город, в котором находится библиотека
        /// </summary>
        /// <value>Город, в котором находится библиотека</value>
        [DataMember(Name="city")]
        public string City { get; set; }

        public LibraryResponse(Guid libraryUid, 
            string name, 
            string address, 
            string city)
        {
            LibraryUid = libraryUid;
            Name = name;
            Address = address;
            City = city;
        }
    }
}
