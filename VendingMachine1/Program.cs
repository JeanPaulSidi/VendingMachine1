namespace VendingMachine1
{
    internal class Program
    {
        static void DisplayMenu(string List)
        {
            Console.WriteLine("******* VENDING MACHINE *******");
            Console.WriteLine();
            Console.WriteLine(List);
            Console.WriteLine("*******************************");
        }

        static int GetUserChoice()
        {
            string Userinput;
            int UserChoice;

            Console.WriteLine();
            Console.Write("Enter your choice: ");
            Userinput = Console.ReadLine();

            while (!int.TryParse(Userinput, out UserChoice))
            {
                Console.Write("Please enter a whole number: ");
                Userinput = Console.ReadLine();
            }

            return UserChoice;
        }
        public static void Log(string selected, int selection, TextWriter Log)
        {
            Log.Write( "\r\nDispensed at : ");
            Log.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            Log.WriteLine($" Option      : {selection}");
            Log.WriteLine($" Item vended : {selected}");
            Log.WriteLine("-------------------------------");
        }


        static void Main(string[] args)
        {
            int UserSelection;
            string PurchasedItem = string.Empty;
            string SelectionList = string.Empty;
            int InventoryCount;

            VendingMachine VendingManager = new VendingMachine();
            do
            {
                SelectionList = VendingManager.GetInventoryList();
                InventoryCount = VendingManager.GetInventoryCount();

                DisplayMenu(SelectionList);
                UserSelection = GetUserChoice();

                while (UserSelection <= 0 || UserSelection > InventoryCount)
                {
                    Console.WriteLine("Input must be between 1 and " + InventoryCount);
                    UserSelection = GetUserChoice();
                }

                PurchasedItem = VendingManager.BuyItem(UserSelection);
                Console.WriteLine();
                Console.WriteLine("Thank you. Vending of " + PurchasedItem + ". Press any key to continue.");

                using (StreamWriter log = File.AppendText("log.txt"))
                {
                    Log(PurchasedItem, UserSelection, log);
                }

                Console.ReadKey();
                Console.Clear();

            } while(true);
        }
    }
}
