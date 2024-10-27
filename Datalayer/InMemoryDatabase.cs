
namespace Models
{
    public class InMemoryDatabase
    {
        public List<Fordon> fordon = new List<Fordon>();
        public List<Station> stationer = new List<Station>();
        public List<Person> personer = new List<Person>();
        public List<Användare> användare = new List<Användare> ();
        public List<Admin> admin = new List<Admin>();
        public List<Hyrning> hyrning = new List<Hyrning>();
        



        public void Seed()
        {
            // Exempel på stationer
            Station station1 = new Station(1, "Mezangata");
            Station station2 = new Station(2, "Båtsman Gråsgata");
            Station station3 = new Station(3, "Båtsman Hisingsgata");
            Station station4 = new Station(4, "Kåserigatan");
            stationer.Add(station1);
            stationer.Add(station2);
            stationer.Add(station3);
            stationer.Add(station4);



            // Exempel på användare (personer)
            Person person1 = new Person("Anna", 1, "123", "Admin");
            Person person2 = new Person("Erik", 2, "abc", "Användare");
            personer.Add(person1);
            personer.Add(person2);

            // Exempel på fordon kopplade till stationer
            Fordon fordon1 = new Fordon(1, "Elcykel", 100, "Tillgänglig", station1);
            Fordon fordon2 = new Fordon(2, "Elscooter", 80, "Tillgänglig", station1);
            Fordon fordon3 = new Fordon(3, "Elcykel", 90, "Tillgänglig", station2);
            Fordon fordon4 = new Fordon(4, "Elscooter", 70, "Tillgänglig", station3);
            Fordon fordon5 = new Fordon(5, "Elcykel", 60, "Tillgänglig", station4);
            fordon.Add(fordon1);
            fordon.Add(fordon2);
            fordon.Add(fordon3);
            fordon.Add(fordon4);
            fordon.Add(fordon5);


        }

    }
}
