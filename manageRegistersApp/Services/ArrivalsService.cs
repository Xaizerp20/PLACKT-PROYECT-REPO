using manageRegistersApp.Data;
using manageRegistersApp.Models;


namespace manageRegistersApp.Services
{
    public class ArrivalsService
    {
        private readonly ArrivalsDataAccess _arrivalsDataAccess;
        private readonly ClientService clientService;

        public ArrivalsService(IConfiguration configuration)
        {
            _arrivalsDataAccess = new ArrivalsDataAccess(configuration);
            clientService = new ClientService(configuration);
        }


        public async Task<List<RegisterArrivals>> GetArrivalsAsync(string _clientName)
        {

            Client client = await clientService.GetClientIdByName(_clientName); //obtiene el id del cliente


            return (await _arrivalsDataAccess.GetArrivalsAsync()).FindAll(a => a.client_id == client.id);
        }

        //Ingresos del dia
        public async Task<List<RegisterArrivals>> GetArrivalsToday(string _clientName)
        {
            List<RegisterArrivals> listArrivals = new List<RegisterArrivals>();
            string currentDate = DateTime.Now.ToShortDateString(); //dia actual

            Client client = await clientService.GetClientIdByName(_clientName); //obtiene el id del cliente


            listArrivals =  await _arrivalsDataAccess.GetArrivalsAsync();

            return listArrivals = listArrivals.FindAll(a => a.Date.ToShortDateString() == currentDate && a.exit_time == null && a.client_id == client.id) ; //filtro de entradas del dia
        }


        public async Task<bool> CreateArrival(RegisterArrivals arrival)
        {
           return await _arrivalsDataAccess.CreateArrival(arrival);
        }

        //registrar salida
        public async Task<bool> UpdateExitTime(int _id)
        {
            return await _arrivalsDataAccess.UpdateExitTime(_id);
        }
    }
}
