using Market.BusinessModel.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.BusinessModel.Models
{
    [Table("tProduct")]
    public class ProductModel : BaseModel, ICreatedEntity
    {
        public string ProductName { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
