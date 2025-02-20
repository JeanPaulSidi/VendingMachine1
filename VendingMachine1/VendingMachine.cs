using System;
using System.IO;

namespace VendingMachine1
{
    internal class Program
    {
        static void DisplayMenu(string list)
        {
            Console.WriteLine("******* VENDING MACHINE *******");
            Console.WriteLine();
            Console.WriteLine(list);
            Console.WriteLine("*******************************");
        }

        static int GetUserChoice(int maxChoice)
        {
            int userChoice;
            while (true)
            {
                Console.Write("Enter your choice (1-" + maxChoice + "): ");
                if (int.TryParse(Console.ReadLine(), out userChoice) && userChoice >= 1 && userChoice <= maxChoice)
                    return userChoice;
                Console.WriteLine("Invalid selection. Please enter a valid option.");
            }
        }

        static decimal GetUserPayment()
        {
            decimal payment;
            while (true)
            {
                Console.Write("Insert money: $");
                if (decimal.TryParse(Console.ReadLine(), out payment) && payment >= 0)
                    return payment;
                Console.WriteLine("Invalid amount. Please enter a valid number.");
            }
        }

        public static void Log(string selected, int selection, decimal price, decimal payment, decimal change, TextWriter log)
        {
            log.WriteLine("\r\nTransaction at: " + DateTime.Now);
            log.WriteLine($"Option      : {selection}");
            log.WriteLine($"Item vended : {selected}");
            log.WriteLine($"Price       : ${price}");
            log.WriteLine($"Payment     : ${payment}");
            log.WriteLine($"Change Given: ${change}");
            log.WriteLine("-------------------------------");
        }

        static void Main(string[] args)
        {
            VendingMachine vendingManager = new VendingMachine();

            while (true)
            {
                string selectionList = vendingManager.GetInventoryList();
                int inventoryCount = vendingManager.GetInventoryCount();

                DisplayMenu(selectionList);

                decimal userPayment = GetUserPayment();
                int userSelection = GetUserChoice(inventoryCount);

                string purchasedItem;
                decimal itemPrice;
                purchasedItem = vendingManager.BuyItem(userSelection, out itemPrice);

                if (userPayment >= itemPrice)
                {
                    decimal change = userPayment - itemPrice;
                    Console.WriteLine($"Thank you! Dispensing {purchasedItem}.");
                    if (change > 0)
                    {
                        Console.WriteLine($"Your change: ${change:F2}");
                    }

                    using (StreamWriter log = File.AppendText("log.txt"))
                    {
                        Log(purchasedItem, userSelection, itemPrice, userPayment, change, log);
                    }
                }
                else
                {
                    Console.WriteLine("Insufficient payment. Transaction canceled.");
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
