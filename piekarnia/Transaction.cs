using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace piekarnia
{
    class Transaction
    {
        public DateTime Date { get; }
        public List<Product> PurchasedItems { get; }
        public string PaymentMethod { get; }

        public Transaction(List<Product> purchasedItems, string paymentMethod)
        {
            Date = DateTime.Now;
            PurchasedItems = purchasedItems;
            PaymentMethod = paymentMethod;
        }
    }
}
