namespace CaravanMVC.Models
{
    public class Passenger
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Destination { get; set; }
        public Wagon Wagon { get; set; }

        public Passenger() { }
        public Passenger(string name, int age, string destination, Wagon wagon) 
        {
            Name = name;
            Age = age;
            Destination = destination;
            Wagon = wagon;
        }
    }
}
