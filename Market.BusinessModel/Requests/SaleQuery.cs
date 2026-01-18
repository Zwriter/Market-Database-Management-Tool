using Market.BusinessModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.BusinessModel.Requests
{
    public class SaleQuery : QueryRequest<SaleSortBy>
    {
        public string? ProductId { get; set; }
        public string? ReceiptId { get; set; }

        public int? MinQuantity { get; set; }
        public int? MaxQuantity { get; set; }
    }
}
