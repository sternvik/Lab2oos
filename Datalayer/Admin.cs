using System;
using System.Collections.Generic;
using System.Linq;

namespace Models
{
    public class Admin : Person
    {
        public Admin(string namn, int användarID, string lösenord, string roll)
        : base(namn, användarID, lösenord, roll) { }

        public void MenuAdmin(InMemoryDatabase inMemoryDatabase)
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
                            LäggTillFordon(inMemoryDatabase.fordon, inMemoryDatabase.stationer);
                            break;
                        case 2:
                            UppdateraFordon(inMemoryDatabase.fordon, inMemoryDatabase.stationer);
                            break;
                        case 3:
                            TaBortFordon(inMemoryDatabase.fordon, inMemoryDatabase.stationer);
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


        public static void LäggTillFordon(List<Fordon> fordonLista, List<Station> stationer)
        {
            Console.WriteLine("Befintliga fordon:");
            Fordon.VisaAllaFordon(fordonLista);

            Console.Write("Ange fordonets ID: ");
            string inputId = Console.ReadLine();
            if (!int.TryParse(inputId, out int id) || fordonLista.Any(f => f.FordonID == id))
            {
                Console.WriteLine("Felaktig inmatning för ID eller fordonet finns redan. Försök igen.");
                return;
            }

            Console.Write("Ange fordonets Typ: ");
            string typ = Console.ReadLine();

            Console.Write("Ange batterinivå: ");
            if (!int.TryParse(Console.ReadLine(), out int batteriNivå))
            {
                Console.WriteLine("Felaktig inmatning för batterinivå.");
                return;
            }

            string status = "Tillgänglig";
            Station.VisaAllaStationer(stationer);

            Console.Write("Ange fordonets StationID: ");
            if (!int.TryParse(Console.ReadLine(), out int stationID))
            {
                Console.WriteLine("Felaktig inmatning för StationID.");
                return;
            }

            Station valdStation = stationer.Find(s => s.StationID == stationID);
            if (valdStation == null)
            {
                Console.WriteLine("Ingen station hittades med det angivna ID.");
                return;
            }

            Fordon nyttFordon = new Fordon(id, typ, batteriNivå, status, valdStation);
            fordonLista.Add(nyttFordon);
            Console.WriteLine($"Fordon {id} har lagts till i systemet.");
        }

        public static void TaBortFordon(List<Fordon> fordonLista, List<Station> stationer)
        {
            Station.VisaAllaStationer(stationer);
            Console.Write("Ange ID på stationen vars fordon du vill visa: ");
            if (!int.TryParse(Console.ReadLine(), out int stationID))
            {
                Console.WriteLine("Felaktig inmatning för StationID.");
                return;
            }

            Station valdStation = stationer.Find(s => s.StationID == stationID);
            if (valdStation == null)
            {
                Console.WriteLine("Ingen station hittades med det angivna ID.");
                return;
            }

            Fordon.VisaFordonPåStation(valdStation);
            Console.Write("Ange ID på fordonet du vill ta bort: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Fordon fordonAttTaBort = fordonLista.Find(f => f.FordonID == id);
                if (fordonAttTaBort != null)
                {
                    valdStation.TillgängligaFordon.Remove(fordonAttTaBort);
                    fordonLista.Remove(fordonAttTaBort);
                    Console.WriteLine($"Fordon med ID {id} har tagits bort.");
                }
                else
                {
                    Console.WriteLine("Inget fordon hittades med det angivna ID.");
                }
            }
            else
            {
                Console.WriteLine("Felaktig inmatning för ID.");
            }
        }

        public static void UppdateraFordon(List<Fordon> fordonLista, List<Station> stationer)
        {
            Station.VisaAllaStationer(stationer);
            Console.Write("Ange ID på stationen vars fordon du vill uppdatera: ");
            if (!int.TryParse(Console.ReadLine(), out int stationID))
            {
                Console.WriteLine("Felaktig inmatning för StationID.");
                return;
            }

            Station valdStation = stationer.Find(s => s.StationID == stationID);
            if (valdStation == null)
            {
                Console.WriteLine("Ingen station hittades med det angivna ID.");
                return;
            }

            Fordon.VisaFordonPåStation(valdStation);
            Console.Write("Ange ID på fordonet du vill uppdatera: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Felaktig inmatning. Ange ett giltigt heltal.");
                return;
            }

            Fordon fordonAttUppdatera = fordonLista.Find(f => f.FordonID == id);
            if (fordonAttUppdatera == null)
            {
                Console.WriteLine($"Inget fordon med ID {id} hittades.");
                return;
            }

            Console.Write($"Nuvarande typ: {fordonAttUppdatera.Typ}. Ange ny typ (lämna tom för att behålla samma): ");
            string nyTyp = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nyTyp))
            {
                fordonAttUppdatera.Typ = nyTyp;
            }

            Console.Write($"Nuvarande batterinivå: {fordonAttUppdatera.BatteriNivå}%. Ange ny batterinivå (lämna tom för att behålla samma): ");
            string inputBatteri = Console.ReadLine();
            if (int.TryParse(inputBatteri, out int nyBatteriNivå))
            {
                fordonAttUppdatera.BatteriNivå = nyBatteriNivå;
            }

            Console.Write($"Nuvarande status: {fordonAttUppdatera.Status}. Ange ny status (lämna tom för att behålla samma): ");
            string nyStatus = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nyStatus))
            {
                fordonAttUppdatera.Status = nyStatus;
            }

            Console.WriteLine($"Fordon med ID {id} har uppdaterats.");
        }
    }
}
