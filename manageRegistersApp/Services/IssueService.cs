using manageRegistersApp.Data;
using manageRegistersApp.Models;



namespace manageRegistersApp.Services
{
    public class IssueService
    {
        private readonly IssueDataAccess _IssueDataAccess;
        private readonly ClientService clientService;

        public IssueService(IConfiguration configuration)
        {
            _IssueDataAccess = new IssueDataAccess(configuration);
            clientService = new ClientService(configuration);
        }


        public async Task<List<Issue>> GetIssuesAsync(string _clientName)
        {

            Client client = await clientService.GetClientIdByName(_clientName); //obtiene el id del cliente

            return await _IssueDataAccess.GetIssuesAsync(client.id);
        }

        public async Task<List<Issue>> GetIssuesByVehicleId(int id_vehicle)
        {
            return await _IssueDataAccess.GetIssuesByVehicleId(id_vehicle);
        }


        public async Task<bool> CreateIssue(Issue issue)
        {
            return await _IssueDataAccess.CreateIssue(issue);
        }

    
        public async Task<bool>ResolveIssue(int id)
        {
           return await _IssueDataAccess.ResolveIssue(id);
        }
    }
}
