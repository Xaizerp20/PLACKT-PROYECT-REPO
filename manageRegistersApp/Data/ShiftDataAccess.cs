using DataLibrary;
using manageRegistersApp.Models;



namespace manageRegistersApp.Data
{
    public class ShiftDataAccess
    {
        private readonly string? _connectionString;
        private readonly DataAccess _data;

        public ShiftDataAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("default"); // Reemplaza "NombreConexion" por el nombre de tu cadena de conexión en la configuración
            _data = new DataAccess();
        }


        //query para obtener lista de turnos POR ID
        public async Task<List<Shifts>> GetShiftsAsyncById(int _clientId)
        {
            try
            {

                string sql = "select * from shifts WHERE client_id = @client_id ";
                return await _data.LoadData<Shifts, dynamic>(sql, new { client_id = _clientId }, _connectionString);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        //query para obtener lista de turnos
        public async Task<List<Shifts>> GetShiftsAsync()
        {
            try
            {

                string sql = "select * from shifts WHERE 1";
                return await _data.LoadData<Shifts, dynamic>(sql, new { }, _connectionString);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        public async Task<bool> CreateShiftAsync(TimeSpan? start, TimeSpan? end, string Horario, int ClienId)
        {
            try
            {
                string sql = "INSERT INTO shifts (Shift_Start, Shift_End, daytime, client_id) VALUES (@Shift_Start, @Shift_End, @daytime, @client_id);";
                int rowsAffected = await _data.SaveData(sql, new { Shift_Start = start, Shift_End = end, daytime = Horario, client_id = ClienId }, _connectionString);
                return rowsAffected > 0;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
          

        }

        public async Task<bool> UpdateShiftAsync(Shifts shift)
        {
            try
            {
                string sql = "UPDATE shifts SET Shift_Start = @Shift_Start, Shift_End = @Shift_End, daytime = @daytime WHERE id = @id;";
                int rowsAffected = await _data.SaveData(sql, shift, _connectionString);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
