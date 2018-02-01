using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafe
{
    class Client
    {
        public float Money = 10.0f;
        public List<Edible> BoughtEdibles = new List<Edible>();

        public void PrintBalance()
        {
            Console.WriteLine("Balanss: " + Money + "€");
        }

        public void PrintBoughtEdibles()
        {
            if (BoughtEdibles.Count == 0)
            {
                Console.WriteLine("Te ei ole ostnud ühtegi toodet");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("Teil on: ");

            foreach (Edible edible in BoughtEdibles)
                Console.WriteLine(edible.Name);

            Console.WriteLine();
        }
    }
}
