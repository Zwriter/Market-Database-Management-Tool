using Market.BusinessModel.Enums;
using Market.BusinessModel.Interfaces;
using Market.BusinessModel.Models;
using Market.BusinessModel.Requests;
using Market.DataAccess.Interfaces;

namespace Market.BusinessLogic.Services
{
    public class ClientService : BaseService<ClientModel, ClientQuery, ClientSortBy>, IClientService
    {
        private readonly IClientRepository _clientRepo;

        public ClientService(IRepository<ClientModel> repo, IClientRepository clientRepo)
            : base(repo)
        {
            _clientRepo = clientRepo ?? throw new ArgumentNullException(nameof(clientRepo));
        }

        public List<ClientModel> GetClients(ClientQuery query)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));
            return _clientRepo.Get(query);
        }

        public void CreateClient(ClientModel client) => Create(client);
        public void UpdateClient(ClientModel client) => Update(client);
        public void DeleteClient(ClientModel client) => Delete(client);
        public bool ExistsClient(string id) => Exists(id);

        public void Save(ClientModel client) => Save(client);
    }
}
