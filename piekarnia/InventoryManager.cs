using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace piekarnia
{

    class InventoryManager
    {
        private Dictionary<string, List<Ingredient>> Inventory;

        public InventoryManager(Dictionary<string, List<Ingredient>> initialInventory)
        {
            Inventory = initialInventory;
        }

        public void UpdateInventory(List<Product> purchasedItems)
        {
            foreach (var product in purchasedItems)
            {
                if (Inventory.ContainsKey(product.Name))
                {
                    foreach (var ingredient in Inventory[product.Name])
                    {
                        // Update the quantity of each ingredient based on the purchased quantity
                        ingredient.Quantity -= product.Quantity;
                    }
                }
            }
        }

        public void DisplayInventory()
        {
            Console.WriteLine("Current Inventory:");

            foreach (var entry in Inventory)
            {
                Console.WriteLine($"Product: {entry.Key}");

                foreach (var ingredient in entry.Value)
                {
                    Console.WriteLine($"- {ingredient.Name}: {ingredient.Quantity} {ingredient.Unit}");
                }

                Console.WriteLine();
            }
        }
    }
}
