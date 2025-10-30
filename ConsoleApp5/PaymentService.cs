using System;

namespace OrderSystem
{
    public class PaymentService
    {
        public bool ProcessPayment(Order order, decimal amountPaid)
        {
            decimal totalAmount = order.CalculateTotal();

            if (amountPaid >= totalAmount)
            {
                Console.WriteLine($"Payment successful! Order {order.OrderId} paid.");
                return true;
            }
            else
            {
                Console.WriteLine($"Payment failed! Insufficient funds for order {order.OrderId}.");
                return false;
            }
        }
    }
}
