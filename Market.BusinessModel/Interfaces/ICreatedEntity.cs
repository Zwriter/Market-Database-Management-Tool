using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.BusinessModel.Interfaces
{
    public interface ICreatedEntity
    {
        DateTime CreatedAt { get; set; }
    }
}
