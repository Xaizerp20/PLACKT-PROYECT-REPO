using DataLibrary;
using manageRegistersApp.Models;
using manageRegistersApp.Services;

namespace manageRegistersApp.Data
{
    public class EmailsDataAccess
    {
        private readonly string? _connectionString;
        private readonly DataAccess _data;

        public EmailsDataAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("default"); // Reemplaza "NombreConexion" por el nombre de tu cadena de conexión en la configuración
            _data = new DataAccess();
        }



        public async Task<List<Email>> GetEmailsAsync()
        {
            try
            {
                string sql = "SELECT * FROM emails WHERE 1";

                return await _data.LoadData<Email, dynamic>(sql, new { }, _connectionString);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }


        }

        public async Task<bool> CreateEmail(Email email)
        {
            try
            {
                string sql = "INSERT INTO emails (email, email_name, client_id) VALUES (@email, @email_name, @client_id);";

                int rowsAffected = await _data.SaveData(sql, email, _connectionString);
                return rowsAffected > 0;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }


        }

        public async Task<bool> UpdateEmail(Email email)
        {
            try
            {
                string sql = "UPDATE emails SET email = @email, email_name = @email_name WHERE id = @id;";

                int rowsAffected = await _data.SaveData(sql, email, _connectionString);
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
