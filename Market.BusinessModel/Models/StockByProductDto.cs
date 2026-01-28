using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.BusinessModel.Models
{
    public class StockByProductDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int TotalStock { get; set; }
        public decimal AvgPrice { get; set; }
    }
}
