namespace manageRegistersApp.Authentication
{
    public class UserSession
    {
        public string UserId { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string Client_Id { get; set; }
        public string Client_Name { get; set; }
    }
}
