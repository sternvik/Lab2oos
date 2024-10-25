using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Station
    {
        public int StationID { get; set; } 
        public string Namn { get; set; }  
        public List<Fordon> TillgängligaFordon { get; set; }

        public Station(int id, string namn)
        {
            StationID = id;
            Namn = namn;
            TillgängligaFordon = new List<Fordon>();
        }
        public void LäggTillFordon(Fordon fordon)
        {
            TillgängligaFordon.Add(fordon);
        }

        public static void VisaAllaStationer(List<Station> stationer)
        {
            Console.WriteLine("Tillgängliga stationer:");
            Console.WriteLine($"Antal stationer: {stationer.Count}");
            foreach (var station in stationer)
            {
                Console.WriteLine($"ID: {station.StationID}, Namn: {station.Namn}");
            }
        }
    }
}
