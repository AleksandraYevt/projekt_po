using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace piekarnia
{
    public class Order
    {
        public List<Product> Items { get; private set; }

        public Order()
        {
            Items = new List<Product>();
        }

        public void AddItem(Product product)
        {
            Items.Add(product);
        }

        public virtual void ApplyDiscount()
        {

        }
        public List<Product> GetItems() => Items;
    }
}
