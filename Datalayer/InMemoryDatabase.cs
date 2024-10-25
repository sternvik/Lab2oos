
namespace Models
{
    public class InMemoryDatabase
    {
        public List<Fordon> fordon = new List<Fordon>();
        public List<Station> stationer = new List<Station>();
        public List<Person> personer = new List<Person>();
        public List<Hyrning> hyrning = new List<Hyrning>();
        private Användare inloggadAnvändare;



        public void Seed()
        {
            // Exempel på stationer
            Station station1 = new Station(1, "MezanGatan");
            Station station2 = new Station(2, "b");
            Station station3 = new Station(3, "c");
            Station station4 = new Station(4, "d");
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

        public void MenuAdmin()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("Välj en åtgärd:");
                Console.WriteLine("1: Lägg till fordon");
                Console.WriteLine("2: Uppdatera fordon");
                Console.WriteLine("3: Ta bort fordon");
                Console.WriteLine("4: Avsluta");
                


                if (int.TryParse(Console.ReadLine(), out int i))
                {
                    switch (i)
                    {
                        case 1:
                            Admin.LäggTillFordon(fordon, stationer);
                            break;
                        case 2:
                            Admin.UppdateraFordon(fordon, stationer);
                            break;
                        case 3:
                            Admin.TaBortFordon(fordon, stationer);
                            break;
                        case 4:
                            running = false; 
                            break;
                        default:
                            Console.WriteLine("Ogiltigt val, försök igen.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Felaktig inmatning, ange ett nummer.");
                }
            }
        }


        public void MenuAnvändare()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("Välj en åtgärd:");
                Console.WriteLine("1: Hyr fordon");
                Console.WriteLine("2: Visa hyreshistorik");
                Console.WriteLine("3: Avsluta");
                

                if (int.TryParse(Console.ReadLine(), out int i))
                {
                    switch (i)
                    {
                        case 1:
                            Hyrning.HyraFordon(inloggadAnvändare, stationer);
                            break;
                        case 2:
                            //VisaHyreshistorik(inloggadAnvändare);
                            break;
                        case 3:
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Ogiltigt val, försök igen.");
                            break;
                    }
                }
            }
        }

        
    }
}
