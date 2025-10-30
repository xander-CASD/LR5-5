using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace OrderSystem.Tests
{
    [TestClass]
    public class OrderServiceTests
    {
        [TestMethod]
        public void CreateOrder_ShouldAddOrderToList()
        {
            // Arrange
            var orderService = new OrderService();
            var order = new Order { OrderId = 1 };

            // Act
            orderService.CreateOrder(order);

            // Assert
            var allOrders = orderService.GetAllOrders();
            Assert.AreEqual(1, allOrders.Count);
            Assert.AreEqual(1, allOrders[0].OrderId);
        }

        [TestMethod]
        public void GetOrder_ExistingOrder_ShouldReturnOrder()
        {
            // Arrange
            var orderService = new OrderService();
            var order = new Order { OrderId = 1 };
            orderService.CreateOrder(order);

            // Act
            var result = orderService.GetOrder(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.OrderId);
        }

        [TestMethod]
        public void GetOrder_NonExistingOrder_ShouldReturnNull()
        {
            // Arrange
            var orderService = new OrderService();

            // Act
            var result = orderService.GetOrder(999);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void CalculateTotal_ShouldReturnCorrectSum()
        {
            // Arrange
            var order = new Order { OrderId = 1 };
            var product1 = new Product(1, "Product1", 100m);
            var product2 = new Product(2, "Product2", 50m);
            order.AddProduct(product1);
            order.AddProduct(product2);

            // Act
            var total = order.CalculateTotal();

            // Assert
            Assert.AreEqual(150m, total);
        }

        [TestMethod]
        public void AddProduct_ShouldIncreaseProductCount()
        {
            // Arrange
            var order = new Order { OrderId = 1 };
            var product = new Product(1, "TestProduct", 10m);

            // Act
            order.AddProduct(product);

            // Assert
            Assert.AreEqual(1, order.Products.Count);
            Assert.AreEqual("TestProduct", order.Products[0].Name);
        }
    }
}
