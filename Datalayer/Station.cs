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
    }
}
