using manageRegistersApp.Data;
using manageRegistersApp.Models;
using BCryptNet = BCrypt.Net.BCrypt;
using MudBlazor;

namespace manageRegistersApp.Services
{
    public class UserService
    {

        private readonly UserDataAccess _userDataAccess;

        public UserService(IConfiguration configuration)
        {
            _userDataAccess = new UserDataAccess(configuration);
        }



        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userDataAccess.GetUserByIdAsync(id);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _userDataAccess.GetUsersAsync();
        }

        public async Task CreateUser(User user)
        {
            // Validaciones o lógica de negocio adicional antes de llamar al repositorio
           await _userDataAccess.CreateUserAsync(user);
        }

        public async Task<bool> UpdateUser(User user)
        {
            User compareUser = await GetUserByIdAsync(user.Id);

            if(compareUser.Password != user.Password){ //comprueba si la password fue cambiada

                user.Password = BCryptNet.HashPassword(user.Password); //encryptar password
            }          
            
           return await _userDataAccess.UpdateUserAsync(user);

        }

        public async Task<bool> UpdateUserStateAsync(int id, bool state)
        {

            // Verificar si el usuario existe
            User user = await _userDataAccess.GetUserByIdAsync(id);

            if (user == null)
            {
                return false;
            }

            // Actualizar el estado del usuario
            user.User_State = state;


            return await _userDataAccess.UpdateUserAsync(user);
        }

        public void EliminarUsuario(int id)
        {
            
            _userDataAccess.DeleteUser(id);
        }


    }
}
