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
        public Station Station { get; set; }
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

        public static Hyrning HyraFordon(Användare användare, List<Station> stationer)
        {

            if (string.IsNullOrEmpty(användare.BetalningsMetod) || string.IsNullOrEmpty(användare.KortNummer))
            {
                Console.WriteLine("Du måste ange betalningsinformation innan du kan hyra ett fordon.");
                return null;
            }


            Station.VisaAllaStationer(stationer);
            Console.WriteLine("Välj en station för uthyrning:");

            int stationIndex;
            if (!int.TryParse(Console.ReadLine(), out stationIndex) || stationIndex < 1 || stationIndex > stationer.Count)
            {
                Console.WriteLine("Ogiltigt val av station.");
                return null;
            }

            Station valdStation = stationer[stationIndex - 1];
            Fordon.VisaFordonPåStation(valdStation);

            Console.Write("Ange ID på fordonet du vill hyra: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Ogiltigt ID.");
                return null;
            }

            Fordon fordonAttHyra = valdStation.TillgängligaFordon.Find(f => f.FordonID == id);
            if (fordonAttHyra == null)
            {
                Console.WriteLine($"Det angivna fordonet finns inte på station {valdStation.Namn}.");
                return null;
            }

            if (fordonAttHyra.Status != "Tillgänglig")
            {
                Console.WriteLine("Det angivna fordonet är inte tillgängligt.");
                return null;
            }

            Console.Write("Ange startdatum (yyyy-mm-dd): ");
            DateTime startDatum;
            if (!DateTime.TryParse(Console.ReadLine(), out startDatum))
            {
                Console.WriteLine("Ogiltigt datumformat. Försök igen.");
                return null;
            }

            Console.Write("Ange starttid (hh:mm): ");
            TimeSpan startTidSpan;
            if (!TimeSpan.TryParse(Console.ReadLine(), out startTidSpan))
            {
                Console.WriteLine("Ogiltig tidsformat. Försök igen.");
                return null;
            }

            DateTime startTid = startDatum.Date.Add(startTidSpan);
            Hyrning nyHyrning = new Hyrning(fordonAttHyra, användare, startTid);
            fordonAttHyra.Status = "Upptagen";

            Console.WriteLine($"Du har hyrt fordon {fordonAttHyra.FordonID} från station {valdStation.Namn}.");
            return nyHyrning;
        }

        public void AvslutaHyrning(List<Fordon> fordon, List<Station> stationer)
        {
            DateTime sluttid;

            while (true)
            {
                Console.Write("Ange slutdatum (yyyy-mm-dd): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime slutDatum))
                {
                    Console.Write("Ange sluttid (hh:mm): ");
                    if (TimeSpan.TryParse(Console.ReadLine(), out TimeSpan slutTidSpan))
                    {
                        sluttid = slutDatum.Date.Add(slutTidSpan);

                        if (sluttid >= StartTid)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Sluttiden måste vara senare än starttiden.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ogiltigt tidsformat. Försök igen.");
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltigt datumformat. Försök igen.");
                }
            }

            Console.WriteLine("Välj en station för att avsluta hyrningen:");
            Station.VisaAllaStationer(stationer);
            Console.Write("Ange stationens nummer: ");

            if (!int.TryParse(Console.ReadLine(), out int stationIndex) || stationIndex < 1 || stationIndex > stationer.Count)
            {
                Console.WriteLine("Ogiltigt val av station.");
                return;
            }

            Station valdStation = stationer[stationIndex - 1];


            Sluttid = sluttid;
            Beräknakostnad();
            UppdateraFordonStatus("Tillgänglig");
            // Ta bort fordonet från den gamla stationen
            Station gamlaStation = Fordon.Station; // Hämta den gamla stationen
            gamlaStation.TillgängligaFordon.Remove(Fordon); // Ta bort fordonet från den gamla stationen

            Fordon.Station = valdStation;
            valdStation.LäggTillFordon(Fordon);
            Användare.Hyreshistorik.Add($"Hyrning av {Fordon.FordonID} från {StartTid} till {Sluttid} på station {valdStation.Namn}. Kostnad: {Kostnad} kr.");
            Console.WriteLine($"Hyrning avslutad. Total kostnad: {Kostnad} kr.");
        }

        private void Beräknakostnad()
        {

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

        private void UppdateraFordonStatus(string nyStatus)
        {
            Fordon.Status = nyStatus;
        }
    }

}
