﻿using System;

namespace OrderSystem
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(int productId, string name, decimal price)
        {
            ProductId = productId;
            Name = name;
            Price = price;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Product: {Name}, Price: {Price}");
        }
    }
}
