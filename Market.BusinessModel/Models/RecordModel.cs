using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.BusinessModel.Models
{
    [Table("tRecord")]
    public class RecordModel : BaseModel
    {
        public string CategoryId { get; set; }
        public string FactoryId { get; set; }
        public string ProductId { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
