using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace piekarnia
{
        class Program
        {
            static void Main()
            {
                BakerySystem bakery = new BakerySystem();
                bakery.DisplayMenu();

                Console.WriteLine("Select a product (enter its number): ");
                int selectedProductIndex = Convert.ToInt32(Console.ReadLine()) - 1;

                if (selectedProductIndex >= 0 && selectedProductIndex < bakery.Products.Count)
                {
                    Product selectedProduct = bakery.Products[selectedProductIndex];

                    Console.WriteLine($"Selected Product: {selectedProduct.Name}");
                    bakery.DisplayIngredients(selectedProduct.Name);

                    Console.WriteLine("Do you want to add this item to the cart? (yes/no): ");
                    string addToCartChoice = Console.ReadLine().ToLower();

                    if (addToCartChoice == "yes")
                    {
                        Console.WriteLine("Enter the quantity you want to purchase: ");
                        int quantity = Convert.ToInt32(Console.ReadLine());

                        bakery.AddToCart(selectedProduct, quantity);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product number.");
                }

                bakery.DisplayCart();

                Console.WriteLine("Do you want to continue shopping? (yes/no): ");
                string continueShoppingChoice = Console.ReadLine().ToLower();

                while (continueShoppingChoice == "yes")
                {
                    bakery.DisplayMenu();

                    Console.WriteLine("Select a product to add to the cart (enter its number): ");
                    selectedProductIndex = Convert.ToInt32(Console.ReadLine()) - 1;

                    if (selectedProductIndex >= 0 && selectedProductIndex < bakery.Products.Count)
                    {
                        Product selectedProduct = bakery.Products[selectedProductIndex];

                        Console.WriteLine($"Selected Product: {selectedProduct.Name}");
                        bakery.DisplayIngredients(selectedProduct.Name);

                        Console.WriteLine("Do you want to add this item to the cart? (yes/no): ");
                        string addToCartChoice = Console.ReadLine().ToLower();

                        if (addToCartChoice == "yes")
                        {
                            Console.WriteLine("Enter the quantity you want to purchase: ");
                            int quantity = Convert.ToInt32(Console.ReadLine());

                            bakery.AddToCart(selectedProduct, quantity);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid product number.");
                    }

                    bakery.DisplayCart();

                    Console.WriteLine("Do you want to continue shopping? (yes/no): ");
                    continueShoppingChoice = Console.ReadLine().ToLower();
                }

                Console.WriteLine("Do you want to finish your purchase? (yes/no): ");
                string finishPurchaseChoice = Console.ReadLine().ToLower();

                if (finishPurchaseChoice == "yes")
                {
                    Console.WriteLine("Enter 'individual' for a personal purchase or 'company' for a company purchase: ");
                    string purchaseType = Console.ReadLine().ToLower();

                    double totalAmount = bakery.CalculateTotalAmount();
                    double discountedAmount = bakery.ApplyDiscount(totalAmount);

                    bakery.DisplayReceipt(purchaseType, totalAmount, discountedAmount);
                }
            }
        }
    }
