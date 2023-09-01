using DataLibrary;
using manageRegistersApp.Models;
using Microsoft.AspNetCore.Components;
using System.Security.Cryptography;

namespace manageRegistersApp.Data
{
    public class VehicleDataAccess
    {
        private readonly string? _connectionString;
        private readonly DataAccess _data;

        public VehicleDataAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("default"); // Reemplaza "NombreConexion" por el nombre de tu cadena de conexión en la configuración
            _data = new DataAccess();
        }


      

        //query para cargar la lista de vehiculos //usada
        public async Task<List<Vehicle>> GetVehiclesAsync()
        {
            try
            {
                string sql = "select * from vehicles";
                return await _data.LoadData<Vehicle, dynamic>(sql, new { }, _connectionString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
           
        }

        //query para buscar los vehiculos mediante el ID
        public async Task<Vehicle> GetVehicleById(int _id)
        {
            try
            {
                string sql = "SELECT * FROM vehicles WHERE id = @id;";
                return (await _data.LoadData<Vehicle, dynamic>(sql, new { id = @_id }, _connectionString)).FirstOrDefault();
            }

            catch (Exception e)
            {
                Console.WriteLine($"Hubo un error al hacer la consulta: {e.Message}");
                return null;
            }


        }

        //query busca los vehiculos mediante la placa //usada
        public async Task<Vehicle> GetVehicleByNumber(string _NumberPlate)
        {
            try
            {
                string sql = "SELECT * FROM vehicles WHERE NumberPlate = @NumberPlate;";
                return (await _data.LoadData<Vehicle, dynamic>(sql, new { NumberPlate = @_NumberPlate }, _connectionString)).FirstOrDefault();
            }

            catch (Exception e)
            {
                Console.WriteLine($"Hubo un error al hacer la consulta: {e.Message}");
                return null;
            }
        }

        //query para agregar nuevo vehiculo //usada
        public async Task<bool> CreateVehicle(Vehicle vehicle)
        {

            try
            {
                string sql = "INSERT INTO vehicles (NumberPlate) VALUES (@NumberPlate);";
                int rowsAffected = await _data.SaveData(sql, vehicle, _connectionString);

                return rowsAffected > 0;
            }

            catch (Exception e)
            {
                Console.WriteLine($"Hubo un error al guardar los datos: {e.Message}");
                return false;
            }



        }




    }
}
