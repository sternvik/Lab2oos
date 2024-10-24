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

        public void RapporteraFordon()
        {
            


        }


    }
}
