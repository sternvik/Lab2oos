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
        public List<Hyrning> Hyreshistorik { get; set; }

        public Användare(string namn, int användarID, string lösenord, string roll)
        : base(namn, användarID, lösenord, roll) { }

        public void RapporteraFordon()
        {
            Console.WriteLine("Tillgängliga fordon:");
            Fordon.VisaAllaFordon();
        
            Console.Write("Ange ID på fordonet du vill rapportera som trasigt: ");
            int id = int.Parse(Console.ReadLine());
        
            Fordon fordonAttRapportera = Fordon.FordonLista.Find(f => f.FordonID == id);
        
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


    }
}
