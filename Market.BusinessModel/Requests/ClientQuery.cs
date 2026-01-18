using Market.BusinessModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.BusinessModel.Requests
{
    public class ClientQuery : QueryRequest<ClientSortBy>
    {
        public string? Name { get; set; }
        public string? Email { get; set; }

        public DateTime? CreatedAfter { get; set; }
        public DateTime? CreatedAtBefore { get; set; }
    }
}
