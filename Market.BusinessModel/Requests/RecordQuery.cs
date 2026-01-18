using Market.BusinessModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.BusinessModel.Requests
{
    public class RecordQuery : QueryRequest<RecordSortBy>
    {
        public string? CategoryId { get; set; } 
        public string? FactoryId { get; set; }  
        public string? ProductId { get; set; }  

        public int? MinStock { get; set; } 
        public int? MaxStock { get; set; } 

        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }

        public DateTime? ExpirationBefore { get; set; }
        public DateTime? ExpirationAfter { get; set; }
    }
}
