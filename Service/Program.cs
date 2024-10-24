using System;
using Models;

namespace Service
{
    public class Program
    {
        private static InMemoryDatabase inMemoryDatabase = new InMemoryDatabase();

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
                    case 1: // Skapa konto
                        Person.SkapaKonto(inMemoryDatabase);
                        Menu();
                        break;

                    case 2: // Logga in
                        Person.LoggaIn(inMemoryDatabase);
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
