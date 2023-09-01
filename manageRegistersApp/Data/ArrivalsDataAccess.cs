using Microsoft.Extensions.Configuration;
using manageRegistersApp.Models;
using DataLibrary;
using Microsoft.AspNetCore.Components;


namespace manageRegistersApp.Data
{
    public class ArrivalsDataAccess
    {

        private readonly string? _connectionString;
        private readonly DataAccess _data;

        public ArrivalsDataAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("default"); // Reemplaza "NombreConexion" por el nombre de tu cadena de conexión en la configuración
            _data = new DataAccess();
        }



        public async Task<RegisterArrivals> GetArrivalByIdAsync(int _id)
        {

            List<RegisterArrivals> QueryList = new List<RegisterArrivals>();

            string sql = "select * from registerarrivals WHERE id = @id";
            QueryList = await _data.LoadData<RegisterArrivals, dynamic>(sql, new { id = _id }, _connectionString);

            return QueryList.FirstOrDefault();
        }

        public async Task<List<RegisterArrivals>> GetArrivalsAsync()
        {
            try
            {
                string sql = @" SELECT ra.id, ra.room, ra.date, ra.exit_time, ra.client_id,  v.NumberPlate, u.Name
                       FROM registerarrivals ra
                       JOIN vehicles v ON v.id = ra.id_vehicle
                       JOIN users u ON  ra.employee_id = u.id";

                return await _data.LoadData<RegisterArrivals, dynamic>(sql, new { }, _connectionString);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al cargar los datos: {e.Message}");
                return null;
            }

        }

        public async Task<bool> CreateArrival(RegisterArrivals arrival)
        {
            try
            {
                string sql = "INSERT INTO registerarrivals (room, date, id_vehicle, client_id, employee_id) VALUES (@room, @date, @id_vehicle, @client_id, @employee_id);";
                int rowsAffected = await _data.SaveData(sql,  arrival, _connectionString);
                return rowsAffected > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Hubo un error al guardar los datos: {e.Message}");
                return false;
            }
        }

        public void UpdateArrival(RegisterArrivals usuario)
        {
            // Lógica para actualizar un usuario existente en la base de datos utilizando los datos del UsuarioDTO
        }

        //query para resolver actualizar la fecha de salida
        public async Task<bool> UpdateExitTime(int _id)
        {
            try
            {

                string sql = "UPDATE `testdb`.`registerarrivals` SET `exit_time` = @exit_time WHERE(`id` = @id);";
                int rowsAffected = await _data.SaveData(sql, new { exit_time = DateTime.Now, id = _id }, _connectionString);

                return rowsAffected > 0;
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar el el registro: {ex.Message}");
                return false;
            }

        }

        public void DeleteArrival(int id)
        {
            // Lógica para eliminar un usuario de la base de datos por su ID
        }


    }
}
