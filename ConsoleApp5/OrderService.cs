using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderSystem
{
    public class OrderService
    {
        private List<Order> orders;

        public OrderService()
        {
            orders = new List<Order>();
        }

        public void CreateOrder(Order order)
        {
            orders.Add(order);
            Console.WriteLine($"Order {order.OrderId} created.");
        }

        public Order GetOrder(int orderId)
        {
            return orders.FirstOrDefault(o => o.OrderId == orderId);
        }

        public List<Order> GetAllOrders()
        {
            return orders;
        }

        public void DisplayAllOrders()
        {
            Console.WriteLine("All Orders:");
            foreach (var order in orders)
            {
                order.DisplayOrder();
                Console.WriteLine("---");
            }
        }
    }
}
