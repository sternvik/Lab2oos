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

            static void Menu()
            {
                int i = 0;
                switch (i)
                {
                    case 1: // Skapa konto
                        Console.WriteLine(); 
                        break;
                    case 2:  // Logga in
                        Console.WriteLine(); 
                        break;
                }

            }

        }
    }
}
