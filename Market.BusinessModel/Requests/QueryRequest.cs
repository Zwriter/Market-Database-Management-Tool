using Market.BusinessModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.BusinessModel.Requests
{
    public abstract class QueryRequest<TSort>
    where TSort : struct, Enum
    {
        public List<string>? Ids { get; set; }

        public TSort? SortBy { get; set; }
        public SortDirection SortDirection { get; set; } = SortDirection.Asc;

        public int? Page { get; set; } = 1;
        public int? PageSize { get; set; } = 20;
    }
}
