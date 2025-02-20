using System;
using System.Collections.Generic;

namespace VendingMachine1
{
    public class VendingMachine
    {
        private readonly List<(string Name, decimal Price)> _inventory = new();

        public VendingMachine()
        {
            InitializeInventory();
        }

        public int GetInventoryCount() => _inventory.Count;

        public string BuyItem(int index, out decimal price)
        {
            var (name, itemPrice) = _inventory[index - 1];
            price = itemPrice;
            return name;
        }

        private void AddToInventory(string item, decimal price) => _inventory.Add((item, price));

        private void InitializeInventory()
        {
            _inventory.Clear();
            AddToInventory("Pepsi", 1.50m);
            AddToInventory("Coke", 1.50m);
            AddToInventory("Snack", 2.00m);
            AddToInventory("Doritos", 1.75m);
            AddToInventory("Mixed Fruit Gummies", 1.25m);
            AddToInventory("Poptarts", 2.25m);
            AddToInventory("Energy Drink", 2.50m);
        }

        public string GetInventoryList()
        {
            var inventoryList = string.Empty;
            for (int i = 0; i < _inventory.Count; i++)
            {
                inventoryList += $"{i + 1}. {_inventory[i].Name} - ${_inventory[i].Price:F2}\n";
            }
            return inventoryList;
        }
    }
}
