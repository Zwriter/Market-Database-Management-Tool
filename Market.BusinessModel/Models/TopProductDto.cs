using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.BusinessModel.Models
{
    public class TopProductDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int TotalQuantity { get; set; }
    }
}