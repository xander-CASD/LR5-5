using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderSystem
{
    public class Order
    {
        public int OrderId { get; set; }
        public List<Product> Products { get; set; }

        public Order()
        {
            Products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public decimal CalculateTotal()
        {
            return Products.Sum(p => p.Price);
        }

        public void DisplayOrder()
        {
            Console.WriteLine($"Order ID: {OrderId}");
            Console.WriteLine("Products:");
            foreach (var product in Products)
            {
                product.DisplayInfo();
            }
            Console.WriteLine($"Total: {CalculateTotal()}");
        }
    }
}