using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Rsoi.Lab2.GatewayService.HttpApi.Models.Enum;

namespace Rsoi.Lab2.GatewayService.HttpApi.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class TakeBookResponse
    {
        /// <summary>
        /// UUID бронирования
        /// </summary>
        /// <value>UUID бронирования</value>
        [DataMember(Name="reservationUid")]
        public Guid ReservationUid { get; set; }

        /// <summary>
        /// Статус бронирования книги
        /// </summary>
        /// <value>Статус бронирования книги</value>
        [DataMember(Name="status")]
        public Status Status { get; set; }

        /// <summary>
        /// Дата начала бронирования
        /// </summary>
        /// <value>Дата начала бронирования</value>
        [DataMember(Name="startDate")]
        public string StartDate { get; set; }

        /// <summary>
        /// Дата окончания бронирования
        /// </summary>
        /// <value>Дата окончания бронирования</value>
        [DataMember(Name="tillDate")]
        public string TillDate { get; set; }

        /// <summary>
        /// Gets or Sets Book
        /// </summary>
        [DataMember(Name="book")]
        public BookInfo Book { get; set; }

        /// <summary>
        /// Gets or Sets Library
        /// </summary>
        [DataMember(Name="library")]
        public LibraryResponse Library { get; set; }

        /// <summary>
        /// Gets or Sets Rating
        /// </summary>
        [DataMember(Name="rating")]
        public UserRatingResponse Rating { get; set; }

        public TakeBookResponse(Guid reservationUid,
            Status status,
            string startDate,
            string tillDate,
            BookInfo book,
            LibraryResponse library,
            UserRatingResponse rating)
        {
            ReservationUid = reservationUid;
            Status = status;
            StartDate = startDate;
            TillDate = tillDate;
            Book = book;
            Library = library;
            Rating = rating;
        }
    }
}
