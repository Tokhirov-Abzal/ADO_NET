using DB;
using DBOperations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

[TestClass]
public class DatabaseAccessTests
{
    private Mock<IDBAccess> _mockDatabaseAccess;
    private Product _testProduct;
    private Order _testOrder;

    [TestInitialize]
    public void SetUp()
    {
        _mockDatabaseAccess = new Mock<IDBAccess>();

        _testProduct = new Product
        {
            Id = 1,
            Name = "Test Product",
            Description = "Test Description",
            Weight = 1.0,
            Height = 2.0,
            Width = 3.0,
            Length = 4.0
        };

        _testOrder = new Order
        {
            Id = 1,
            Status = Status.NotStarted,
            CreateDate = DateTime.Now,
            UpdateDate = DateTime.Now,
            Product = _testProduct
        };
    }

    [TestMethod]
    public void AddProduct_ShouldCallAddProductOnce()
    {

        _mockDatabaseAccess.Setup(x => x.AddProduct(It.IsAny<Product>()));
        _mockDatabaseAccess.Object.AddProduct(_testProduct);
        _mockDatabaseAccess.Verify(x => x.AddProduct(It.Is<Product>(p => p == _testProduct)), Times.Once);
    }

    [TestMethod]
    public void AddOrder_ShouldCallAddOrderOnce()
    {
        _mockDatabaseAccess.Setup(x => x.AddOrder(It.IsAny<Order>()));
        _mockDatabaseAccess.Object.AddOrder(_testOrder);
        _mockDatabaseAccess.Verify(x => x.AddOrder(It.Is<Order>(o => o == _testOrder)), Times.Once);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException), "Product with provided ID does not exist")]
    public void AddOrder_WithNonExistingProduct_ShouldThrowArgumentException()
    {
        var wrongOrder = new Order
        {
            Id = 2,
            Status = Status.NotStarted,
            CreateDate = DateTime.Now,
            UpdateDate = DateTime.Now,
            Product = new Product { Id = 99 }
        };

        _mockDatabaseAccess.Setup(x => x.AddOrder(It.IsAny<Order>()))
            .Throws(new ArgumentException("Product with provided ID does not exist"));

        _mockDatabaseAccess.Object.AddOrder(wrongOrder);

    }
}