using manageRegistersApp.Data;
using manageRegistersApp.Models;
using BCryptNet = BCrypt.Net.BCrypt;
using MudBlazor;

namespace manageRegistersApp.Services
{
    public class VehicleService
    {

        private readonly VehicleDataAccess _vehicleDataAccess;

        public VehicleService(IConfiguration configuration)
        {
            _vehicleDataAccess = new VehicleDataAccess(configuration);
        }

        public async Task<List<Vehicle>> GetVehiclesAsync()
        {
            return await _vehicleDataAccess.GetVehiclesAsync();
        }

        public async Task<bool> CreateVehicle(Vehicle vehicle)
        {
            return await _vehicleDataAccess.CreateVehicle(vehicle);
        }

    }
}
