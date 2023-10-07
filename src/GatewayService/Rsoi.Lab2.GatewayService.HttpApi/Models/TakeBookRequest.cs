using System.Runtime.Serialization;
using System.Text;

namespace Rsoi.Lab2.GatewayService.HttpApi.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class TakeBookRequest
    {
        /// <summary>
        /// UUID книги
        /// </summary>
        /// <value>UUID книги</value>
        [DataMember(Name="bookUid")]
        public Guid BookUid { get; set; }

        /// <summary>
        /// UUID библиотеки
        /// </summary>
        /// <value>UUID библиотеки</value>
        [DataMember(Name="libraryUid")]
        public Guid LibraryUid { get; set; }

        /// <summary>
        /// Дата окончания бронирования
        /// </summary>
        /// <value>Дата окончания бронирования</value>
        [DataMember(Name="tillDate")]
        public string TillDate { get; set; }

        public TakeBookRequest(Guid bookUid, 
            Guid libraryUid,
            string tillDate)
        {
            BookUid = bookUid;
            LibraryUid = libraryUid;
            TillDate = tillDate;
        }
    }
}
