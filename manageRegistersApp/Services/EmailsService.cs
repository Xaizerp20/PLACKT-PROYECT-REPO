using manageRegistersApp.Data;
using manageRegistersApp.Models;

namespace manageRegistersApp.Services
{
    public class EmailsService
    {
        private readonly EmailsDataAccess _emailDataAccess;
        private readonly ClientService clientService;

        public EmailsService(IConfiguration configuration)
        {
            _emailDataAccess = new EmailsDataAccess(configuration);
            clientService = new ClientService(configuration);
        }


        public async Task<List<Email>> GetEmailsAsync(string _clientName)
        {
            Client client = await clientService.GetClientIdByName(_clientName); //obtiene el id del cliente
            return (await _emailDataAccess.GetEmailsAsync()).FindAll(e => e.client_id == client.id);
        }

        public async Task<List<Email>> GetEmailsByIdAsync(int clientId)
        {
            Console.WriteLine((await _emailDataAccess.GetEmailsAsync()).FindAll(e => e.client_id == clientId).Count());
            return (await _emailDataAccess.GetEmailsAsync()).FindAll(e => e.client_id == clientId);
        }

        public async Task<bool> CreateEmail(Email email)
        {
            return await _emailDataAccess.CreateEmail(email);
        }

        public async Task<bool> UpdateEmail(Email email)
        {
            return await _emailDataAccess.UpdateEmail(email);
        }
        

    }
}
