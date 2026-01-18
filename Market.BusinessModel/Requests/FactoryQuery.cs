using Market.BusinessModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.BusinessModel.Requests
{
    public class FactoryQuery : QueryRequest<FactorySortBy>
    {
        public string? FactoryName { get; set; }
        public DateTime? CreatedAfter { get; set; }
    }
}
