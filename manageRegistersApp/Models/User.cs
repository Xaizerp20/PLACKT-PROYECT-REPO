using DataLibrary;

namespace manageRegistersApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Role { get; set; } = null!;
        public bool User_State { get; set; } = true;
        public int client_id { get; set; }

    }
}

    


  


