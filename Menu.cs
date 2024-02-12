using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaDB
{
    internal class Menu
    {
        public void ShowMenu()
        {
            Console.WriteLine("Meny:");
            Console.WriteLine("1. Se alla elever");
            Console.WriteLine("2. Se alla elever i en viss klass");
            Console.WriteLine("3. Lägg till ny Personal");
            Console.WriteLine("4. Hur många lärare jobbar på skolan");
            Console.WriteLine("5. Hur många administratörer jobbar på skolan");
            Console.WriteLine("6. Visa info om alla lever på skolan");
            Console.WriteLine("7. Visa alla kurser på skolan");

            Console.WriteLine("0. Avsluta");
        }

        public string GetUserChoice()
        {
            return Console.ReadLine();
        }
    }
}
