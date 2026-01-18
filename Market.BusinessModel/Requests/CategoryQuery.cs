using Market.BusinessModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.BusinessModel.Requests
{
    public class CategoryQuery : QueryRequest<CategorySortBy>
    {
        public string? CategoryName { get; set; }
        public DateTime? CreatedAtAfter { get; set; }
    }
}
