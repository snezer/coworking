namespace Coworking.DA.Models
{
    public class Coworking
    {
        public Coworking() {  }

        public long Id { get; set; }
        public string? Adress { get; set; }
        public string? Description { get; set; }
        public bool IsHasWiFi { get; set; }
        public bool IsWholeBuilding { get; set; }
        public int NumberOfFloors { get; set; }
        public int NumberOfWiFiPoints { get; set; }
        public int Rating { get; set; }
        public int TotalSeats { get; set; }
        public int FreeSeats { get; set; }
    }
}
