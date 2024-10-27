using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Användare : Person
    {
        public string BetalningsMetod { get; set; }
        public string KortNummer { get; set; }
        public List<string> Hyreshistorik { get; set; }

        public Användare(string namn, int användarID, string lösenord, string roll)
        : base(namn, användarID, lösenord, roll) 
        {
            Hyreshistorik = new List<string>();
        }

        public void MenuAnvändare(InMemoryDatabase inMemoryDatabase, Användare inloggadAnvändare)
        {
            bool running = true;
            Hyrning aktivHyrning = null;

            while (running)
            {
                Console.WriteLine("\nVälj en åtgärd:");
                Console.WriteLine("1: Hyr fordon");
                Console.WriteLine("2: Avsluta hyra");
                Console.WriteLine("3: Rapportera fordon");
                Console.WriteLine("4: Visa hyreshistorik");
                Console.WriteLine("5: Lägg till betalningsmetod");
                Console.WriteLine("6: Avsluta");

                // Läs användarens val
                if (int.TryParse(Console.ReadLine(), out int val))
                {
                    switch (val)
                    {
                        case 1:
                            aktivHyrning = Hyrning.HyraFordon(inloggadAnvändare, inMemoryDatabase.stationer);
                            break;
                        case 2:
                            if (aktivHyrning != null)
                            {
                                aktivHyrning.AvslutaHyrning(inMemoryDatabase.fordon, inMemoryDatabase.stationer);
                                aktivHyrning = null;
                            }
                            else
                            {
                                Console.WriteLine("Ingen aktiv hyra att avsluta.");
                            }
                            break;
                        case 3:
                            RapporteraFordon(inMemoryDatabase);
                            break;
                        case 4:
                            VisaHyreshistorik(inloggadAnvändare);
                            break;
                        case 5:
                            StällinBetalningsinformation(inloggadAnvändare);
                            break;
                        case 6:
                            running = false; // Avsluta menyn
                            break;
                        default:
                            Console.WriteLine("Ogiltigt val, försök igen.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltigt val, försök igen.");
                }
            }
        }


        public static void RapporteraFordon(InMemoryDatabase inMemoryDatabase)
        {
            Station.VisaAllaStationer(inMemoryDatabase.stationer);

            Console.Write("Ange ID på stationen vars fordon du vill visa: ");
            int stationID = int.Parse(Console.ReadLine());

            Station valdStation = inMemoryDatabase.stationer.Find(s => s.StationID == stationID);
            if (valdStation == null)
            {
                Console.WriteLine("Ingen station hittades med det angivna ID.");
                return;
            }

            Fordon.VisaFordonPåStation(valdStation);

            Console.Write("Ange ID på fordonet du vill rapportera som trasigt: ");
            int id = int.Parse(Console.ReadLine());

            Fordon fordonAttRapportera = inMemoryDatabase.fordon.Find(f => f.FordonID == id);

            if (fordonAttRapportera != null)
            {
                fordonAttRapportera.Status = "Trasig";
                Console.WriteLine($"Fordon med ID {id} har rapporterats som trasigt.");
            }
            else
            {
                Console.WriteLine("Inget fordon hittades med det angivna ID.");
            }
        }

        public void StällinBetalningsinformation(Användare användare)
        {
            Console.WriteLine("Ange betalningsmetod:");
            BetalningsMetod = Console.ReadLine();

            Console.WriteLine("Ange kortnummer:");
            KortNummer = Console.ReadLine();

            Console.WriteLine("Betalningsinformation har sparats.");
        }

        public void VisaHyreshistorik(Användare användare)
        {
            if (Hyreshistorik.Count == 0)
            {
                Console.WriteLine("Ingen hyreshistorik tillgänglig.");
            }
            else
            {
                Console.WriteLine("Hyreshistorik:");
                foreach (var hyra in Hyreshistorik)
                {
                    Console.WriteLine(hyra);
                }
            }
        }



    }
}
