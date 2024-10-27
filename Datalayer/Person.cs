using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Person
    {
        public string Namn { get; set; }
        public int AnvändarID { get; set; }
        public string Lösenord { get; set; }
        public string Roll {  get; set; }

        public Person(string namn, int användarID, string lösenord, string roll)
        {
            this.Namn = namn;
            this.AnvändarID = användarID;
            this.Lösenord = lösenord;
            this.Roll = roll;
        }


        public static void SkapaKonto(InMemoryDatabase inMemoryDatabase)
        {
            Console.WriteLine("Skriv in användarnamn: ");
            string namn = Console.ReadLine();

            // Kontrollera om användarnamnet redan finns
            if (inMemoryDatabase.personer.Any(p => p.Namn == namn))
            {
                Console.WriteLine("Användarnamnet är redan taget. Försök med ett annat namn.");
                return;
            }

            Console.WriteLine("Skriv in Lösenord: ");
            string lösenord = Console.ReadLine();

            Console.WriteLine("Vad för roll har du? 1 eller 2. 1: Admin, 2: Användare. ");
            int rollVal = int.Parse(Console.ReadLine());
            string roll;

            if (rollVal == 1)
            {
                roll = "Admin";
            }
            else if (rollVal == 2)
            {
                roll = "Användare";
            }
            else
            {
                Console.WriteLine("Fel: Vänligen ange antingen 1 eller 2.");
                return;
            }

            int nyttID = inMemoryDatabase.personer.Count + 1;
            Person nyPerson = new Person(namn, nyttID, lösenord, roll);

            inMemoryDatabase.personer.Add(nyPerson);

            Console.WriteLine("Konto skapades framgångsrikt.");
        }


        public static void LoggaIn(InMemoryDatabase inMemoryDatabase)
        {
            Console.Write("Skriv in användarnamn: ");
            string användarnamn = Console.ReadLine();

            Console.Write("Skriv in lösenord: ");
            string lösenord = Console.ReadLine();

            Person inloggadPerson = inMemoryDatabase.personer
                .Find(p => p.Namn == användarnamn && p.Lösenord == lösenord);

            if (inloggadPerson != null)
            {
                Console.WriteLine($"Inloggad som {inloggadPerson.Namn}. Din roll: {inloggadPerson.Roll}");

                
                if (inloggadPerson.Roll == "Admin")
                {
                    
                    Admin admin = new Admin(inloggadPerson.Namn, inloggadPerson.AnvändarID, inloggadPerson.Lösenord, inloggadPerson.Roll);
                    admin.MenuAdmin(inMemoryDatabase); 
                }
                else if (inloggadPerson.Roll == "Användare")
                {
                    Användare användare = new Användare(inloggadPerson.Namn, inloggadPerson.AnvändarID, inloggadPerson.Lösenord, inloggadPerson.Roll);
                    användare.MenuAnvändare(inMemoryDatabase, användare); 
                }

            }
            else
            {
                Console.WriteLine("Felaktigt användarnamn eller lösenord.");
            }
        }
    }
}
