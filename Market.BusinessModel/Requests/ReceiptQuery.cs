using Market.BusinessModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.BusinessModel.Requests
{
    public class ReceiptQuery : QueryRequest<ReceiptSortBy>
    {
        public string? ClientId { get; set; }
        public DateTime? CreatedAfter { get; set; }
    }
}
