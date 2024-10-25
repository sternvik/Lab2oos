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



        public static void RapporteraFordon(List<Station> stationer, List<Fordon> fordonLista)
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

            Console.Write("Ange ID på fordonet du vill rapportera som trasigt: ");
            int id = int.Parse(Console.ReadLine());

            Fordon fordonAttRapportera = fordonLista.Find(f => f.FordonID == id);

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



        public void StällinBetalningsinformation()
        {
            Console.Write("Ange Betalningsmetod: ");
            BetalningsMetod = Console.ReadLine();

            Console.Write("Ange Kortnummer: ");
            KortNummer = Console.ReadLine();
        }

    }
}
