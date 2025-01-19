namespace VendingMachine1
{
    internal class Program
    {
        static void DisplayMenu(string List)
        {
            Console.WriteLine("******* VENDING MACHINE *******");
            Console.WriteLine();
            Console.WriteLine(List);
            //Console.WriteLine();
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


        static void Main(string[] args)
        {
            int UserSelection;
            string PurchasedItem = string.Empty;
            string SelectionList = string.Empty;
            int InventoryCount;

            VendingMachine VendingMachine = new VendingMachine();

            SelectionList = VendingMachine.GetInventoryList();
            InventoryCount = VendingMachine.GetInventoryCount();

            DisplayMenu(SelectionList);
            UserSelection = GetUserChoice();

            while (UserSelection <= 0 || UserSelection > InventoryCount)
            {
                Console.WriteLine("Input must be between 1 and " + InventoryCount);
                UserSelection = GetUserChoice();
            }

            PurchasedItem = VendingMachine.BuyItem(UserSelection);
            Console.WriteLine();
            Console.WriteLine("Thank you. Vending of " + PurchasedItem);
        }
    }
}
