using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Admin : Person
    {
        public Admin(string namn, int användarID, string lösenord, string roll)
        : base(namn, användarID, lösenord, roll) { }

        public static void LäggTillFordon(List<Fordon> fordonLista, List<Station> stationer)
        {
            
            Console.WriteLine("Befintliga fordon:");
            Fordon.VisaAllaFordon(fordonLista);

            Console.Write("Ange fordonets ID: ");
            string inputId = Console.ReadLine();
            int id;

            if (!int.TryParse(inputId, out id))
            {
                Console.WriteLine("Felaktig inmatning för ID. Ange ett giltigt heltal.");
                return;
            }

            
            if (fordonLista.Any(f => f.FordonID == id))
            {
                Console.WriteLine($"Fordon med ID {id} finns redan. Vänligen ange ett unikt ID.");
                return;
            }

            Console.Write("Ange fordonets Typ: ");
            string typ = Console.ReadLine();

            Console.Write("Ange batterinivå: ");
            string inputBatteri = Console.ReadLine();
            int batteriNivå;

            if (!int.TryParse(inputBatteri, out batteriNivå))
            {
                Console.WriteLine("Felaktig inmatning för batterinivå. Ange ett giltigt heltal.");
                return;
            }

            
            string status = "Tillgänglig";

           
            Station.VisaAllaStationer(stationer);

            Console.Write("Ange fordonets StationID: ");
            string InputstationID = Console.ReadLine();
            int stationID;

            if (!int.TryParse(InputstationID, out stationID))
            {
                Console.WriteLine("Felaktig inmatning för StationID. Ange ett giltigt heltal.");
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
            int stationID = int.Parse(Console.ReadLine());

            Station valdStation = stationer.Find(s => s.StationID == stationID);
            if (valdStation == null)
            {
                Console.WriteLine("Ingen station hittades med det angivna ID.");
                return;
            }

            Fordon.VisaFordonPåStation(valdStation);

            Console.Write("Ange ID på fordonet du vill ta bort: ");
            int id = int.Parse(Console.ReadLine());

            Fordon fordonAttTaBort = fordonLista.Find(f => f.FordonID == id);

            if (fordonAttTaBort != null)
            {
                fordonLista.Remove(fordonAttTaBort);
                Console.WriteLine($"Fordon med ID {id} har tagits bort."); //tar inte bort ur den faktiska listan major problem
            }
            else
            {
                Console.WriteLine("Inget fordon hittades med det angivna ID.");
            }
        }

        public static void UppdateraFordon(List<Fordon> fordonLista, List<Station> stationer)
        {
            
            Station.VisaAllaStationer(stationer);

            Console.Write("Ange ID på stationen vars fordon du vill uppdatera: ");
            int stationID = int.Parse(Console.ReadLine());

            Station valdStation = stationer.Find(s => s.StationID == stationID);
            if (valdStation == null)
            {
                Console.WriteLine("Ingen station hittades med det angivna ID.");
                return;
            }

            
            Fordon.VisaFordonPåStation(valdStation);

            Console.Write("Ange ID på fordonet du vill uppdatera: ");
            string inputId = Console.ReadLine();
            int id;

            if (!int.TryParse(inputId, out id))
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
            int nyBatteriNivå;
            if (int.TryParse(inputBatteri, out nyBatteriNivå))
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
