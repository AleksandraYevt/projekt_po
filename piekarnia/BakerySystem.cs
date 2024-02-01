using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace piekarnia
{
    class BakerySystem
    {
        public List<Product> Products { get; private set; }
        private Dictionary<string, List<Ingredient>> Ingredients;
        private List<Product> Cart;

        public BakerySystem()
        {
            Products = ReadProductsFromFile("Products.txt");
            Ingredients = ReadIngredientsFromFile("Ingredients.txt");
            Cart = new List<Product>();
        }

        public void DisplayMenu()
        {
            Console.WriteLine("Menu:");

            for (int i = 0; i < Products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Products[i].Name} - ${Products[i].Price}");
            }
        }

        public void DisplayIngredients(string productName)
        {
            if (Ingredients.ContainsKey(productName))
            {
                Console.WriteLine("Ingredients:");

                foreach (var ingredient in Ingredients[productName])
                {
                    Console.WriteLine($"- {ingredient.DisplayQuantity} x {ingredient.Name}");
                }

                Console.WriteLine();
            }
        }

        public void AddToCart(Product product, int quantity)
        {
            Product productCopy = new Product(product.Name, quantity, product.Price);
            Cart.Add(productCopy);
            Console.WriteLine($"{quantity} x {product.Name} added to the cart.");
        }

        public void DisplayCart()
        {
            Console.WriteLine("Shopping Cart:");

            foreach (var item in Cart)
            {
                Console.WriteLine($"{item.Quantity} x {item.Name} - ${item.Price}");
            }

            Console.WriteLine();
        }

        public double CalculateTotalAmount()
        {
            double totalAmount = 0;

            foreach (var item in Cart)
            {
                totalAmount += item.Price * item.Quantity;
            }

            return totalAmount;
        }

        public double ApplyDiscount(double totalAmount)
        {
            int discountPercentage = Cart.Count;
            double discountAmount = (discountPercentage / 100.0) * totalAmount;
            double discountedAmount = totalAmount - discountAmount;

            return discountedAmount;
        }

        private List<Product> ReadProductsFromFile(string filename)
        {
            List<Product> products = new List<Product>();

            try
            {
                string[] lines = File.ReadAllLines(filename);

                foreach (var line in lines)
                {
                    string[] parts = line.Split(':');
                    string name = parts[0];
                    double price = Convert.ToDouble(parts[1]);

                    products.Add(new Product(name, 1, price));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file {filename}: {ex.Message}");
            }

            return products;
        }

        private Dictionary<string, List<Ingredient>> ReadIngredientsFromFile(string filename)
        {
            Dictionary<string, List<Ingredient>> ingredients = new Dictionary<string, List<Ingredient>>();

            try
            {
                string[] lines = File.ReadAllLines(filename);

                foreach (var line in lines)
                {
                    string[] parts = line.Split(';');
                    string productName = parts[0];
                    string[] ingredientNames = parts[1].Split(',');
                    int[] ingredientQuantities = Array.ConvertAll(parts[2].Split(','), int.Parse);
                    string[] ingredientUnits = parts[3].Split(',');

                    List<Ingredient> productIngredients = new List<Ingredient>();

                    for (int i = 0; i < ingredientNames.Length; i++)
                    {
                        Ingredient ingredient = new Ingredient
                        {
                            Name = ingredientNames[i].Trim(),
                            Quantity = ingredientQuantities[i],
                            Unit = ingredientUnits[i].Trim()
                        };
                        productIngredients.Add(ingredient);
                    }

                    ingredients.Add(productName, productIngredients);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file {filename}: {ex.Message}");
            }

            return ingredients;
        }
        public void DisplayReceipt(string purchaseType, double totalAmount, double discountedAmount)
        {
            Console.WriteLine("Receipt:");
            Console.WriteLine($"1) Customer Type: {purchaseType}");
            Console.WriteLine("2) Purchased Items:");

            foreach (var item in Cart)
            {
                Console.WriteLine($"   - {item.Quantity} x {item.Name} - ${item.Price} each");
            }

            Console.WriteLine($"3) Discount: ${(totalAmount - discountedAmount):F2}");
            Console.WriteLine($"4) Final Amount: ${discountedAmount:F2}");

            Console.WriteLine("Select payment method ('card' or 'cash'): ");
            string paymentMethod = Console.ReadLine().ToLower();

            if (paymentMethod == "card")
            {
                Console.WriteLine("Payment successful. Thank you for your purchase!");
            }
            else if (paymentMethod == "cash")
            {
                Console.WriteLine("Please provide cash. Thank you for your purchase!");
            }
            else
            {
                Console.WriteLine("Invalid payment method. Exiting...");
            }
        }
        public void ProcessOrder(Order order)
        {
            Console.WriteLine("Order Accepted:");

            foreach (var item in order.GetItems())
            {
                Console.WriteLine($"{item.Quantity} x {item.Name}");
                DisplayIngredients(item.Name);
            }

            order.ApplyDiscount();

            Console.WriteLine("Generated ingredients and created invoice.");
        }
    }
}
