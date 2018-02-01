using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafe
{
    class Cafe
    {
        Client client;
        List<Edible> allCoffees;
        List<Edible> allFoods;

        public void InitializeAllCoffees()
        {
            allCoffees = new List<Edible>();

            allCoffees.Add(new coffees.Americano());
            allCoffees.Add(new coffees.Cappucino());
            allCoffees.Add(new coffees.Espresso());
            allCoffees.Add(new coffees.Latte());
            allCoffees.Add(new coffees.Machiatto());
            allCoffees.Add(new coffees.Mocha());
        }

        public void InitializeAllFoods()
        {
            allFoods = new List<Edible>();

            allFoods.Add(new foods.Cake());
            allFoods.Add(new foods.Hamburger());
            allFoods.Add(new foods.Pizza());
            allFoods.Add(new foods.Salad());
            allFoods.Add(new foods.Wrap());
        }

        public Cafe()
        {
            InitializeAllFoods();
            InitializeAllCoffees();
            
            client = new Client();
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("1. Telli toitu");
                Console.WriteLine("2. Telli kohvi");
                Console.WriteLine("3. Vaata ostetud tooteid");
                Console.WriteLine("4. Lahku");
                Console.WriteLine();
                client.PrintBalance();

                string userInput = Console.ReadLine();

                Console.Clear();

                switch (userInput)
                {
                    case "1":
                        Order(allFoods);
                        break;

                    case "2":
                        Order(allCoffees);
                        break;

                    case "3":
                        client.PrintBoughtEdibles();
                        break;

                    case "4":
                        Exit();
                        return;

                    default:
                        Console.WriteLine("Teadmata käsk");
                        Console.WriteLine();
                        break;
                }
            }

        }

        public void Order(List<Edible> edibleList)
        {
            while (true)
            {
                int userInput;
                int i;

                for (i = 0; i < edibleList.Count; i++)
                    Console.WriteLine((i + 1) + ". " + edibleList[i].Name
                                    + " - " + edibleList[i].Cost + "€");
                Console.WriteLine((i + 1) + ". Tagasi");
                Console.WriteLine();
                client.PrintBalance();

                try
                {
                    userInput = Int32.Parse(Console.ReadLine());
                }

                catch
                {
                    Console.WriteLine("Peate sisestama numbri");
                    continue;
                }

                Console.Clear();

                if (userInput == (i + 1))
                    return;

                if (userInput > 0 && userInput <= edibleList.Count + 1)
                {
                    Edible currentEdible = edibleList[userInput - 1];

                    if (client.Money < currentEdible.Cost)
                        Console.WriteLine("Sul pole piisavalt raha");

                    else
                    {
                        Console.WriteLine("Sa ostsid " + currentEdible.Name);
                        client.Money -= currentEdible.Cost;
                        client.BoughtEdibles.Add(currentEdible);
                    }
                }

                else
                    Console.WriteLine("Peab olema numbri vahemikus");

                Console.WriteLine();
            }
        }

        public void Exit()
        {

        }
    }
}
