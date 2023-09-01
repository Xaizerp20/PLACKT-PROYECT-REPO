namespace manageRegistersApp.Models
{
    public class RegisterArrivals
    {
        public int id { get; set; }

        public int Room { get; set; }

        public DateTime Date { get; set; }

        public string NumberPlate { get; set; } = null!;

        public int id_vehicle { get; set; }

        public DateTime? exit_time { get; set; }

        public int client_id {get; set;}

        public int employee_id { get; set; }

        public string Name { get; set; }

        //public DateTime DepartureTime { get; set; }

        //public Vehicle Vehicle { get; }


    }
}
