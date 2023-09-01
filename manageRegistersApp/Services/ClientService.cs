using manageRegistersApp.Data;
using manageRegistersApp.Models;
using MudBlazor.Extensions;

namespace manageRegistersApp.Services
{
    public class ClientService
    {
        private readonly ClientDataAccess _clientDataAccess;

        public ClientService(IConfiguration configuration)
        {
            _clientDataAccess = new ClientDataAccess(configuration);
        }

        public async Task<List<Client>> GetClientsAsync()
        {

            return await _clientDataAccess.GetClientsAsync();
        }

        public async Task<Client> GetClientIdByName(string _name)
        {

            Client? client  = (await _clientDataAccess.GetClientIdByName(_name)).FirstOrDefault();

            return client;
        }

        public async Task<bool> CreateClient(Client client)
        {
            return await _clientDataAccess.CreateClient(client);
        }

        public async Task<bool> UpdateClient(Client client)
        {
            return await _clientDataAccess.UpdateClient(client);
        }

    }
}
