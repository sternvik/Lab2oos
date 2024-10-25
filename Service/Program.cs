using System;
using Models;

namespace Service
{
    public class Program
    {
        private static InMemoryDatabase inMemoryDatabase = new InMemoryDatabase();
        private static Person inloggadAnvändare;
        private static List<Station> stationer = new List<Station>();
        private static List<Fordon> fordonLista = new List<Fordon>();
        static void Main(string[] args)
        {
            inMemoryDatabase.Seed();
            Menu();
        }

        static void Menu()
        {
            Console.WriteLine("Välj ett alternativ:");
            Console.WriteLine("1. Skapa konto");
            Console.WriteLine("2. Logga in");

            if (int.TryParse(Console.ReadLine(), out int i))
            {
                switch (i)
                {
                    case 1: 
                        Person.SkapaKonto(inMemoryDatabase);
                        Menu();
                        break;

                    case 2: 
                        Person.LoggaIn(inMemoryDatabase, stationer, fordonLista);
                        break;

                    default:
                        Console.WriteLine("Ogiltigt val. Vänligen försök igen.");
                        Menu();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Ogiltig inmatning. Vänligen ange ett nummer.");
                Menu();
            }
        }
    }
}
