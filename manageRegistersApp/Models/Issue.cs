namespace manageRegistersApp.Models
{
    public class Issue
    {
        public int id { get; set; }

        public string Issue_Type { get; set; } = null!;

        public DateTime Open_Date { get; set;}

        public string Status { get; set; } = "PENDING";

        public DateTime Resolve_Date { get; set; }
        
        public string? Description { get; set; }

        public string NumberPlate { get; set; } = null!;

        public int vehicle_Id { get; set; }

        public string? client_DNI { get; set; }

        public int client_id { get; set; }

        public int employee_id { get; set; } 

        public string Name { get; set; } = null!;


    }

}
