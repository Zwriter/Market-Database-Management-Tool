using Market.BusinessModel.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Market.BusinessModel.Models
{
    [Table("tClient")]
    public class ClientModel : BaseModel, ICreatedEntity, IUpdatedEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}