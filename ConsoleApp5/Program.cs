using System;

namespace OrderSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Product product1 = new Product(1, "Laptop", 999.99m);
            Product product2 = new Product(2, "Mouse", 25.50m);
            Product product3 = new Product(3, "Keyboard", 75.00m);

            
            Order order1 = new Order { OrderId = 1 };
            order1.AddProduct(product1);
            order1.AddProduct(product2);

            Order order2 = new Order { OrderId = 2 };
            order2.AddProduct(product2);
            order2.AddProduct(product3);

            
            OrderService orderService = new OrderService();
            orderService.CreateOrder(order1);
            orderService.CreateOrder(order2);

            
            orderService.DisplayAllOrders();

            
            Order retrievedOrder = orderService.GetOrder(1);
            if (retrievedOrder != null)
            {
                Console.WriteLine("Retrieved Order:");
                retrievedOrder.DisplayOrder();
            }

            Console.ReadLine();
        }
    }
}