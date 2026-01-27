using Market.BusinessModel.Models;
using Market.BusinessModel.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.BusinessModel.Interfaces
{
    public interface IClientService
    {
        List<ClientModel> GetClients(ClientQuery query);
        ClientModel GetClientsById(string id);
        void CreateClient(ClientModel client);
        void UpdateClient(ClientModel client);
        void DeleteClient(ClientModel client);
        bool Exists(string id);
        void Save(ClientModel client);
    }
}
