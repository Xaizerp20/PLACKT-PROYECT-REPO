using DataLibrary;

namespace manageRegistersApp.Models
{
    public class Shifts
    {
        public int id { get; set; }
        public TimeSpan Shift_Start { get; set; }
        public TimeSpan Shift_End { get; set; }
        public string daytime { get; set; }
        public int client_id { get; set; }


        public static List<Shifts> shiftsList = new List<Shifts>();

    }

}
