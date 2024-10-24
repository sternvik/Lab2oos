using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Fordon
    {
        public static List<Fordon> FordonLista = new List<Fordon>();

        public int FordonID { get; set; }
        public string Typ { get; set; }
        public int BatteriNivå { get; set; }
        public string Status { get; set; }

        public Fordon(int id, string typ, int batteriNivå, string status)
        {
            FordonID = id;
            Typ = typ;
            BatteriNivå = batteriNivå;
            Status = status;  
        }

        public void UppdateraStatus()
        {
            
        }


        public static void VisaAllaFordon()
        {
            Console.WriteLine("Fordon i systemet:");
            foreach (var fordon in FordonLista)
            {
                Console.WriteLine($"ID: {fordon.FordonID}, Typ: {fordon.Typ}, Batterinivå: {fordon.BatteriNivå}, Status: {fordon.Status}");
            }
        }

    }
}
