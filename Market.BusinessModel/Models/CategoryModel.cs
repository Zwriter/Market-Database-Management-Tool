using Market.BusinessModel.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.BusinessModel.Models
{
    [Table("tCategory")]
    public class CategoryModel : BaseModel, ICreatedEntity
    {
        public string CategoryName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
