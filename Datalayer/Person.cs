using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Person
    {
        public string Namn { get; set; }
        public int AnvändarID { get; set; }
        private string Lösenord { get; set; }
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
        
            if (inMemoryDatabase.personer.Any(p => p.Namn == namn))
            {
                Console.WriteLine("Användarnamnet är redan taget. Försök med ett annat namn.");
                return;
            }
            Console.WriteLine("Skriv in Lösenord: ");
            string lösenord = Console.ReadLine();
        
            Console.WriteLine("Vad för roll har du? 1 eller 2. 1: Admin, 2: Användare. ");
            int rollwhat = int.Parse(Console.ReadLine());
            string Vilkenroll;
        
            if (rollwhat == 1) { Vilkenroll = "Admin"; }
            else { Vilkenroll = "Användare"; }
        
            int nyttID = inMemoryDatabase.personer.Count + 1; 
            Person nyPerson = new Person(namn, nyttID, lösenord, Vilkenroll);
        
            inMemoryDatabase.personer.Add(nyPerson);
        
            Console.WriteLine("Konto skapades framgångsrikt.");
    
        }
        
        public static void LoggaIn(InMemoryDatabase inMemoryDatabase)
        {
    
            Console.Write("Skriv in användarnamn: ");
            string användarnamn = Console.ReadLine(); 
        
            Console.Write("Skriv in lösenord: ");
            string lösenord = Console.ReadLine();
        
            // Leta efter användare med matchande namn och lösenord.. Denna e skum men de bara att fatta
            Person användare = inMemoryDatabase.personer.Find(p => p.Namn == användarnamn && p.Lösenord == lösenord);
        
            if (användare != null)
            {
                Console.WriteLine($"Inloggad som {användare.Namn}.");
                Console.WriteLine("");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Felaktigt användarnamn eller lösenord.");
            }
        }
    }
}
