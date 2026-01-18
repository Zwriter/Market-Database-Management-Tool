using Market.BusinessModel.Models;
using Market.BusinessModel.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.DataAccess.Interfaces
{
    public interface IClientRepository
    {
        List<ClientModel> Get(ClientQuery query);
    }

}
