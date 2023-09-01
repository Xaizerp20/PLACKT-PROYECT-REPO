using DataLibrary;
using manageRegistersApp.Models;
using Microsoft.AspNetCore.Components;
using System.Security.Cryptography;

namespace manageRegistersApp.Data
{
    public class UserDataAccess
    {
        private readonly string? _connectionString;
        private readonly DataAccess _data;

        public UserDataAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("default"); // Reemplaza "NombreConexion" por el nombre de tu cadena de conexión en la configuración
            _data = new DataAccess();
        }



        public async Task<User> GetUserByIdAsync(int _id)
        {

            List<User> QueryList = new List<User>();

            string sql = "select * from users WHERE id = @id";
            QueryList = await _data.LoadData<User, dynamic>(sql, new { id = _id }, _connectionString);

            return QueryList.FirstOrDefault();
        }

        public async Task<List<User>> GetUsersAsync()
        {

            string sql = "select * from users";
            return await _data.LoadData<User, dynamic>(sql, new { }, _connectionString);
        }

        public async Task CreateUserAsync(User user)
        {
            string sql = "INSERT INTO users (Name, Password, Email, Role, client_id) VALUES (@name, @password, @email, @role, @client_id);";
            await _data.SaveData(sql, user, _connectionString);
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            try
            {
                string sql = "UPDATE `testdb`.`users` SET `Name` = @Name, Password = @Password, Email = @Email, Role = @Role, User_State = @User_State WHERE(`Id` = @Id)";
                int rowsAffected = await _data.SaveData(sql, user, _connectionString);

                return rowsAffected > 0;     // Devuelve true si se actualizó al menos una fila
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar el usuario: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateUserStateAsync(int id, bool state)
        {
            try
            {
                string sql = "UPDATE `testdb`.`users` SET User_State = @State WHERE Id = @Id";
                var parameters = new { Id = id, User_State = state };
                int rowsAffected = await _data.SaveData(sql, parameters, _connectionString);
                return rowsAffected > 0;
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar el estado del usuario: {ex.Message}");
                return false;
            }

        }

        public void DeleteUser(int id)
        {
            // Lógica para eliminar un usuario de la base de datos por su ID
        }

    }
}
