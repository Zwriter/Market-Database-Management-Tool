using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.BusinessModel.Models
{
    public class EarningsByDateDto
    {
        public DateTime SaleDate { get; set; }
        public decimal TotalEarnings { get; set; }
    }
}
