using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafe.coffees
{
    class Americano : Edible
    {
        public Americano()
        {
            Name = "Americano";
            Cost = 2.4f;
        }

        public override void Buy(Client client)
        {
            Console.WriteLine("Sa ajasid kohvi ümber ja maksad räigelt");

            client.Money -= 35;

            if (client.Money < 0)
                client.Money = 0;
        }
    }
}
