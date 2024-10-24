using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Hyrning

    {
        

       

        public void HyraFordon()
        {
            
            Fordon.VisaAllaFordon();

            Console.Write("Ange ID på fordonet du vill hyra: ");
            int id = int.Parse(Console.ReadLine());

            
            Fordon fordonAttHyra = Fordon.FordonLista.Find(f => f.FordonID == id);

            if (fordonAttHyra != null)
            {
                if (fordonAttHyra.Status == "Tillgänglig")
                {
                    fordonAttHyra.Status = "Upptagen";
                    Console.WriteLine($"Fordon med ID {id} har hyrts ut.");
                }
                else
                {
                    Console.WriteLine("Fordonet är inte tillgängligt.");
                }
            }
            else
            {
                Console.WriteLine("Inget fordon hittades med det angivna ID.");
            }
        }



    }
    
}
