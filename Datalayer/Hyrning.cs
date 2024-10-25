using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Hyrning
    {
        public Fordon Fordon { get; private set; }
        public DateTime StartTid { get; private set; }
        public DateTime Sluttid { get; private set; }
        public double Kostnad { get; private set; }
        public Användare Användare { get; private set; }

        public Hyrning(Fordon fordon, Användare användare, DateTime startTid)
        {
            Fordon = fordon;
            Användare = användare;
            StartTid = startTid; 
            Kostnad = 0;
        }

        public void AvslutaHyrning(DateTime sluttid)
        {
            //någon form av avsluta hyrning yaney
            Sluttid = sluttid;
            Beräknakostnad();
            UppdateraFordonStatus("Tillgänglig");
            Användare.Hyreshistorik.Add($"Hyrning av {Fordon.FordonID} från {StartTid} till {Sluttid}. Kostnad: {Kostnad} kr.");
            Console.WriteLine($"Hyrning avslutad. Total kostnad: {Kostnad} kr.");
        }

        private void Beräknakostnad()
        {

            // någon form av inmatning med kostnad typ 
            if (Sluttid > StartTid)
            {
                TimeSpan hyrestid = Sluttid - StartTid;
                double minutkostnad = 2;
                Kostnad = hyrestid.TotalMinutes * minutkostnad;
            }
            else
            {
                Console.WriteLine("Sluttid måste vara senare än starttid.");
            }
        }

        /* Hyrprocessen: En användare ska kunna hyra ett fordon vid en specifik station. Systemet
ska kontrollera att fordonet är tillgängligt och att användarens betalningsmetod är giltig
innan uthyrningen påbörjas. Under hyran ska systemet logga tid och kostnad. När
användaren avslutar hyran vid en station, ska systemet uppdatera fordonets status och
användarens hyreshistorik.*/
        public static void HyraFordon(Användare användare, List<Station> stationer)
        {

            Station.VisaAllaStationer(stationer);
            Console.WriteLine("Välj en station för uthyrning:");



            int stationIndex;
            if (!int.TryParse(Console.ReadLine(), out stationIndex) || stationIndex < 1 || stationIndex > stationer.Count)
            {
                Console.WriteLine("Ogiltigt val av station.");
                return;
            }

            Station valdStation = stationer[stationIndex - 1];
            Fordon.VisaFordonPåStation(valdStation);

            Console.Write("Ange ID på fordonet du vill hyra: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Ogiltigt ID.");
                return;
            }

            Fordon fordonAttHyra = valdStation.TillgängligaFordon.Find(f => f.FordonID == id);
            if (fordonAttHyra == null)
            {
                Console.WriteLine($"Det angivna fordonet finns inte på station {valdStation.Namn}.");
                return;
            }

            if (fordonAttHyra.Status != "Tillgänglig")
            {
                Console.WriteLine("Det angivna fordonet är inte tillgängligt.");
                return;
            }

            Console.Write("Ange startdatum (yyyy-mm-dd): ");
            DateTime startDatum;
            if (!DateTime.TryParse(Console.ReadLine(), out startDatum))
            {
                Console.WriteLine("Ogiltigt datumformat. Försök igen.");
                return;
            }

            Console.Write("Ange starttid (hh:mm): ");
            TimeSpan startTidSpan;
            if (!TimeSpan.TryParse(Console.ReadLine(), out startTidSpan))
            {
                Console.WriteLine("Ogiltig tidsformat. Försök igen.");
                return;
            }

            DateTime startTid = startDatum.Date.Add(startTidSpan);
            Hyrning nyHyrning = new Hyrning(fordonAttHyra, användare, startTid);
            fordonAttHyra.Status = "Upptagen";

            Console.WriteLine($"Du har hyrt fordon {fordonAttHyra.FordonID} från station {valdStation.Namn}.");
        }


        private void UppdateraFordonStatus(string nyStatus)
        {
            Fordon.Status = nyStatus;
        }
    }

}
