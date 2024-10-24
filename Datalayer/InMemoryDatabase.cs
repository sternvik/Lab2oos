namespace Models
{
    public class InMemoryDatabase
    {

        public List <Fordon> fordon = new List <Fordon> ();
        public List <Station> station = new List <Station> ();
        public List<Användare> användare = new List<Användare> ();
        public List <Person> person = new List <Person> ();
        public List <Hyrning> hyrning = new List <Hyrning> ();
        public List <Admin> admin = new List <Admin> ();


        public void Seed()
        {
            Station station1 = new Station(1, "");
            Station station2 = new Station(2, "");
            Station station3 = new Station(3, "");
            Station station4 = new Station(4, "");


        }
    }
}
