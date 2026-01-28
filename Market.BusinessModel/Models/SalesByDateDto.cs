using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.BusinessModel.Models
{
    public class SalesByDateDto
    {
        public DateTime SaleDate { get; set; }
        public int TotalQuantity { get; set; }
        public int SalesCount { get; set; }
    }
}