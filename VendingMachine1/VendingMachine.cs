using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine1
{
    public class VendingMachine
    {
        private List<string> _inventory = new List<string>();

        public VendingMachine()
        {
            InitializeInventory();
        }

        public int GetInventoryCount()
        {
            return _inventory.Count;
        }

        public string BuyItem(int Index)
        {
            return _inventory[Index - 1];
        }

        private void AddToInventory(string Item)
        {
            _inventory.Add(Item);
        }

        private void InitializeInventory()
        {
            _inventory.Clear();

            AddToInventory("Pepsi");
            AddToInventory("Coke");
            AddToInventory("Snack");
            AddToInventory("Doritos");
            AddToInventory("Mixed Fruit Gummies");
            AddToInventory("Poptarts");
            AddToInventory("Energy Drink");

        }

        public string GetInventoryList()
        {
            string InventoryList = string.Empty;

            for (int i = 0; i < _inventory.Count; i++)
            {
                InventoryList += (i + 1) + " " + _inventory[i] + "\n";
            }

            return InventoryList;
        }

    }
}
