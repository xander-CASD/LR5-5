using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OrderSystem.Tests
{
    [TestClass]
    public class PaymentIntegrationTests
    {
        [TestMethod]
        public void ProcessPayment_SufficientFunds_ShouldReturnTrue()
        {
            // Arrange
            var order = new Order { OrderId = 1 };
            order.AddProduct(new Product(1, "Laptop", 1000m));
            var paymentService = new PaymentService();

            // Act
            bool result = paymentService.ProcessPayment(order, 1200m);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ProcessPayment_InsufficientFunds_ShouldReturnFalse()
        {
            // Arrange
            var order = new Order { OrderId = 1 };
            order.AddProduct(new Product(1, "Laptop", 1000m));
            var paymentService = new PaymentService();

            // Act
            bool result = paymentService.ProcessPayment(order, 500m);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void OrderService_And_PaymentService_Integration()
        {
            // Arrange
            var orderService = new OrderService();
            var paymentService = new PaymentService();

            var order = new Order { OrderId = 1 };
            order.AddProduct(new Product(1, "Mouse", 25m));
            order.AddProduct(new Product(2, "Keyboard", 75m));

            orderService.CreateOrder(order);

            // Act
            var retrievedOrder = orderService.GetOrder(1);
            bool paymentResult = paymentService.ProcessPayment(retrievedOrder, 100m);

            // Assert
            Assert.IsNotNull(retrievedOrder);
            Assert.AreEqual(100m, retrievedOrder.CalculateTotal());
            Assert.IsTrue(paymentResult);
        }
    }
}