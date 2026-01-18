using Market.BusinessModel.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.BusinessModel.Models
{
    [Table("tReceipt")]
    public class ReceiptModel : BaseModel, ICreatedEntity
    {
        public int ClientId { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
