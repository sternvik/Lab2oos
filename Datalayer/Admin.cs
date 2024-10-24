using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Admin : Person
    {
        

        public void LäggTillFordon(Fordon fordon)
        {
            Console.Write("Ange fordonets ID: ");
            string inputId = Console.ReadLine();
            int id;

            if (!int.TryParse(inputId, out id))
            {
                Console.WriteLine("Felaktig inmatning för ID. Ange ett giltigt heltal.");
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

            Console.Write("Ange fordonets Status: ");
            string status = Console.ReadLine();

            Fordon nyttFordon = new Fordon(id, typ, batteriNivå, status);

            Fordon.FordonLista.Add(nyttFordon);

            Console.WriteLine($"Fordon {id} har lagts till i systemet.");

        }

        public void TaBortFordon(Fordon fordon)
        {
            Console.WriteLine("Tillgängliga fordon");
            Fordon.VisaAllaFordon();

            Console.Write("Ange Id på fordonet du vill ta bort: ");
            int id = int.Parse(Console.ReadLine());

            Fordon fordonAttTaBort = Fordon.FordonLista.Find(f => f.FordonID == id);

            if (fordonAttTaBort != null)
            {
                Fordon.FordonLista.Remove(fordonAttTaBort);
                Console.WriteLine($"Fordon med ID {id} har tagits bort. ");
            }
            else 
            {
                Console.WriteLine("Inget fordon hittades med det angivna ID");
            }

        }

        public void UppdateraFordon(Fordon fordon)
        {
            Console.WriteLine("Tillgängliga fordon");
            Fordon.VisaAllaFordon();

            Console.Write("Ange ID på fordonet du vill uppdatera: ");
            string inputId = Console.ReadLine();
            int id;

            if (!int.TryParse(inputId, out id))
            {
                Console.WriteLine("Felaktig inmatning. Ange ett giltigt heltal.");
                return;
            }

            Fordon fordonAttUppdatera = Fordon.FordonLista.Find(f => f.FordonID == id);

            if (fordonAttUppdatera == null)
            {
                Console.WriteLine($"inget fordon med ID {id} hittades.");
                return;
            }

            Console.Write($"Nuvarande typ: {fordonAttUppdatera.Typ}. Ange ny typ: ");
            string nyTyp = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nyTyp))
            {
                fordonAttUppdatera.Typ = nyTyp;
            }

            Console.Write($"Nuvarande batterinivå: {fordonAttUppdatera.BatteriNivå}%. Ange ny batterinivå: ");
            string inputBatteri = Console.ReadLine();
            int nyBatteriNivå;

            Console.Write($"Nuvarande status: {fordonAttUppdatera.Status}. Ange ny status: ");
            string nyStatus = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nyStatus))
            {
                fordonAttUppdatera.Status = nyStatus;
            }

            Console.WriteLine($"Fordon med ID {id} har uppdaterats.");

        }

    }
}
