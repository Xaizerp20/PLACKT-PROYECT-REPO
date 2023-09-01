namespace manageRegistersApp.Models
{
    public class Email
    {
        public int id { get; set; }
        public string email { get; set; } = null!;
        public string? email_name { get; set; } 
        public int client_id { get; set;}
    }
}
