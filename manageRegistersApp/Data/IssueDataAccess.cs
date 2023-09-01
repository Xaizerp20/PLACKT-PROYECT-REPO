using Microsoft.Extensions.Configuration;
using manageRegistersApp.Models;
using DataLibrary;
using Microsoft.AspNetCore.Components;


namespace manageRegistersApp.Data
{
    public class IssueDataAccess
    {

        private readonly string? _connectionString;
        private readonly DataAccess _data;

        public IssueDataAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("default"); // Reemplaza "NombreConexion" por el nombre de tu cadena de conexión en la configuración
            _data = new DataAccess();
        }


        //string _Issue_Type, string _Issues_Description, int _id_vehicle

        public async Task<Issue> GetIssueByIdAsync(int _id)
        {

            List<Issue> QueryList = new List<Issue>();
          
            string sql = "select * from Issue WHERE id = @id";
            QueryList =  await _data.LoadData<Issue, dynamic>(sql, new { id = _id }, _connectionString);

            return QueryList.FirstOrDefault();
        }

        public async Task<List<Issue>> GetIssuesAsync(int client)
        {
            try
            {
                string sql = @"SELECT i.id, i.Issue_Type, i.Open_Date, i.Status, i.Resolve_Date, i.Description,  v.NumberPlate, i.client_DNI, u.Name
                       FROM issues i
                       JOIN vehicles v ON v.id = i.vehicle_Id
                       JOIN users u ON  i.employee_id = u.id
                       WHERE i.client_id = @client_id;";

                return await _data.LoadData<Issue, dynamic>(sql, new { client_id = @client }, _connectionString);
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error al cargar los datos: {e.Message}");
                return null;
            }
           
        }

        //query para comprobar si el vehiculo tiene Issues pendientes
        public async Task<List<Issue>> GetIssuesByVehicleId(int id_vehicle)
        {
            try
            {
                string sql = "SELECT * FROM issues WHERE vehicle_Id = @vehicle_Id AND Status = 'PENDING';";
                return await _data.LoadData<Issue, dynamic>(sql, new { vehicle_Id = @id_vehicle }, _connectionString);
            }

            catch (Exception e)
            {
                Console.WriteLine($"Hubo un error al hacer la consulta: {e.Message}");
                return null;
            }
        }


        //query agregar nuevo issue
        public async Task<bool> CreateIssue(Issue issue)
        {
            try
            {
                string sql = "INSERT INTO issues (Issue_Type, Description, vehicle_Id, client_id, employee_id) VALUES (@Issue_Type, @Description, @vehicle_Id, @client_id, employee_id);";
                int rowsAffected = await _data.SaveData(sql, issue, _connectionString);
                return rowsAffected > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                Console.WriteLine($"Stack Trace: {e.StackTrace}");
                return false;
            }
        }

        public void UpdateIssue(Issue usuario)
        {
            // Lógica para actualizar un usuario existente en la base de datos utilizando los datos del UsuarioDTO
        }


        //query para resolver los issues
        public async Task<bool> ResolveIssue(int _id)
        {
            try
            {
                string sql = "UPDATE `testdb`.`issues` SET `Status` = 'RESOLVED', `Resolve_Date` = @Resolve_Date WHERE(`id` = @id);";
                int rowsAffected = await _data.SaveData(sql, new { id = _id, Resolve_Date = DateTime.Now }, _connectionString);
                return rowsAffected > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
         

        }


    }
}
