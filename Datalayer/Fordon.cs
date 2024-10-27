using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Models
{
    public class Fordon
    {
        public int FordonID { get; set; }
        public string Typ { get; set; }
        public int BatteriNivå { get; set; }
        public string Status { get; set; }
        public Station Station { get; set; }

        public Fordon(int id, string typ, int batteriNivå, string status, Station station)
        {
            FordonID = id;
            Typ = typ;
            BatteriNivå = batteriNivå;
            Status = status;
            Station = station; 
            station.LäggTillFordon(this);
        }

        public static void VisaFordonPåStation(Station station)
        {
            Console.WriteLine($"Fordon på station {station.Namn}:");

            if (station.TillgängligaFordon.Count == 0)
            {
                Console.WriteLine("Inga fordon på denna station.");
            }
            else
            {
                foreach (var fordon in station.TillgängligaFordon)
                {
                    Console.WriteLine($"ID: {fordon.FordonID}, Typ: {fordon.Typ}, Batterinivå: {fordon.BatteriNivå}, Status: {fordon.Status}");
                }
            }
        }


        public static void VisaAllaFordon(List<Fordon> fordonLista)
        {
            Console.WriteLine("Fordon i systemet:");
            foreach (var fordon in fordonLista)
            {
                Console.WriteLine($"ID: {fordon.FordonID}, Typ: {fordon.Typ}, Batterinivå: {fordon.BatteriNivå}, Status: {fordon.Status}");
            }
        }
    }
}
