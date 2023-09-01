using DataLibrary;
using manageRegistersApp.Models;


namespace manageRegistersApp.Data
{
    public class ClientDataAccess
    {
        private readonly string? _connectionString;
        private readonly DataAccess _data;

        public ClientDataAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("default"); // Reemplaza "NombreConexion" por el nombre de tu cadena de conexión en la configuración
            _data = new DataAccess();
        }


        public async Task<List<Client>> GetClientsAsync()
        {
            try
            {
                string sql = "SELECT * FROM client WHERE 1";

                return await _data.LoadData<Client, dynamic>(sql, new { }, _connectionString);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }


        }

        public async Task<List<Client>> GetClientIdByName(string _name)
        {
            string sql = "SELECT id FROM client Where name = @name";

            return await _data.LoadData<Client, dynamic>(sql, new { name = _name }, _connectionString);


        }

        public async Task<bool> CreateClient(Client client)
        {
            try
            {
                string sql = "INSERT INTO Client (name, creation_date, contact, location) VALUES (@name, @creation_date, @contact, @location);";
                int rowsAffected = await _data.SaveData(sql, client, _connectionString);
                return rowsAffected > 0;
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return false;
            }
           
        }

        public async Task<bool> UpdateClient(Client client)
        {
            try
            {
                string sql = "UPDATE `testdb`.`Client` SET name = @name, contact = @contact, location = @location WHERE id = @id";
                int rowsAffected = await _data.SaveData(sql, client, _connectionString);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            };
        }
    }
}
