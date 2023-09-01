using LiteDB;
using Newtonsoft.Json;


namespace manageRegistersApp.Models
{
    public class Vehicle
    {
        public int id { get; set; }
        public string NumberPlate { get; set; } = null!;

        public int Pending_Issues { get; set; }

        public int Resolved_Issues { get; set; }

    }


}
