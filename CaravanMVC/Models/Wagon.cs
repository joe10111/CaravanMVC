namespace CaravanMVC.Models
{
    public class Wagon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumWheels { get; set; }
        public bool Covered { get; set; }
        public Passenger Passengers { get; set; }

        public Wagon() { }
        public Wagon(string name, int numWheels, bool covered, Passenger passengers)
        {
            Name = name;
            NumWheels = numWheels;
            Covered = covered;
            Passengers = passengers;
        }
    }
}
