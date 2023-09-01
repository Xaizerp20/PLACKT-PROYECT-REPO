using DataLibrary;
using Microsoft.CodeAnalysis;

namespace manageRegistersApp.Models
{
    public class Client
    {
        public int id { get; set; } 
        public string name { get; set; } = null!;
        public DateTime creation_date { get; set; } = DateTime.Now;
        public string? contact { get; set; }
        public string? location { get; set; }


        public static List<Client> clientList = new List<Client>();


        public static async void GetAllClients()
        {
            DataAccess _data = new DataAccess();
            string sql = "select * from client";
            clientList = await _data.LoadData<Client, dynamic>(sql, new { }, "Server=localhost;Port=3306;database=testdb;user id=root;password=2639");
        }
    }
}
