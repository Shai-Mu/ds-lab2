using System.Runtime.Serialization;
using System.Text;

namespace Rsoi.Lab2.GatewayService.HttpApi.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class LibraryBookPaginationResponse
    {
        /// <summary>
        /// Номер страницы
        /// </summary>
        /// <value>Номер страницы</value>
        [DataMember(Name="page")]
        public decimal? Page { get; set; }

        /// <summary>
        /// Количество элементов на странице
        /// </summary>
        /// <value>Количество элементов на странице</value>
        [DataMember(Name="pageSize")]
        public decimal? PageSize { get; set; }

        /// <summary>
        /// Общее количество элементов
        /// </summary>
        /// <value>Общее количество элементов</value>
        [DataMember(Name="totalElements")]
        public decimal TotalElements { get; set; }

        /// <summary>
        /// Gets or Sets Items
        /// </summary>
        [DataMember(Name="items")]
        public List<LibraryBookResponse> Items { get; set; }

        public LibraryBookPaginationResponse(decimal? page,
            decimal? pageSize,
            decimal totalElements,
            List<LibraryBookResponse> items)
        {
            Page = page;
            PageSize = pageSize;
            TotalElements = totalElements;
            Items = items;
        }
    }
}
