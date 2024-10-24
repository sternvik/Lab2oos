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
                // Switch case logga in "ahh"

            }

        }
    }
}
