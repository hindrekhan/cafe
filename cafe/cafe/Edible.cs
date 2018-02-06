using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafe
{
    class Edible
    {
        public string Name;
        public float Cost;

        public virtual void Buy(Client client)
        {
            Console.WriteLine("Sa ostsid " + Name);
            client.Money -= Cost;
            client.BoughtEdibles.Add(this);
        }

        public void PrintOrder(int count)
        {
            Console.WriteLine((count + 1) + ". " + Name + " - " + Cost + "€");
        }
    }
}
