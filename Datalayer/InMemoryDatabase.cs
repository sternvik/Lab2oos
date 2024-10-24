namespace Models
{
    public class InMemoryDatabase
    {

        public List <Fordon> fordon = new List <Fordon> ();
        public List <Station> station = new List <Station> ();
        public List<Användare> användare = new List<Användare> ();
        public List <Person> personer = new List <Person> ();
        public List <Hyrning> hyrning = new List <Hyrning> ();
        public List <Admin> admin = new List <Admin> ();


        public void Seed()
        {
            Station station1 = new Station(1, "MezanGatan");
            Station station2 = new Station(2, "");
            Station station3 = new Station(3, "");
            Station station4 = new Station(4, "");

            station.Add(station1);
            station.Add(station2);
            station.Add(station3);
            station.Add(station4);
            
            Person person1 = new Person("Anna", 1, "123", "Admin" );
            Person person2 = new Person("Erik", 2, "abc", "Användare");
            
            personer.Add(person1);
            personer.Add(person2);


        }
        public void MenuAdmin()
        {
            Console.WriteLine("Välj en åtgärd:");
            Console.WriteLine("1: Lägg till fordon");
            Console.WriteLine("2: Ta bort fordon");
            Console.WriteLine("3: Uppdatera fordon");
            Console.WriteLine("4: Avsluta");
        
            int i;
            if (int.TryParse(Console.ReadLine(), out i))
                switch (i)
            {
                case 1:
                        Admin.LäggTillFordon();
                    break;
                case 2:
                        Admin.TaBortFordon();
                    break;
                case 3:
                        Admin.UppdateraFordon();
                    break;
                case 4:
                        Console.WriteLine("ss");
                    break;
            }
        
        
        } 
        public void MenuAnvändare()
        {
            Console.WriteLine("hej använd");
        }
    }
}
