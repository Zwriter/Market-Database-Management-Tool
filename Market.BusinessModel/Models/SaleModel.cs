using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.BusinessModel.Models
{
    [Table("tSale")]
    public class SaleModel : BaseModel
    {
        public string ReceiptId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
