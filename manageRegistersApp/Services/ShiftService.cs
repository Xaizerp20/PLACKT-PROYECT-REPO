using manageRegistersApp.Data;
using manageRegistersApp.Models;

namespace manageRegistersApp.Services
{
    public class ShiftService
    {
        private readonly ShiftDataAccess _shiftDataAccess;
        private readonly ClientService clientService;


        public ShiftService(IConfiguration configuration)
        {
            _shiftDataAccess = new ShiftDataAccess(configuration);
            clientService = new ClientService(configuration);
        }

        public async Task<List<Shifts>> GetShiftsAsyncById(string _clientName)
        {

            Client client = await clientService.GetClientIdByName(_clientName); //obtiene el id del cliente

            return (await _shiftDataAccess.GetShiftsAsyncById(client.id)).FindAll(s => s.client_id == client.id);
        }

        public async Task<List<Shifts>> GetShiftsAsync()
        {
            return await _shiftDataAccess.GetShiftsAsync();
        }

        public async Task<bool> CreateShift(TimeSpan? start, TimeSpan? end, string Horario, int ClienId)
        {
            return await _shiftDataAccess.CreateShiftAsync(start, end, Horario, ClienId);
        }

        public async Task<bool> UpdateShift(Shifts shift)
        {
            return await _shiftDataAccess.UpdateShiftAsync(shift);
        }
    }
}
