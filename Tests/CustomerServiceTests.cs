using Microsoft.EntityFrameworkCore;
using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Services;

namespace ProvaPub.Tests
{
    public class CustomerServiceTests
    {
        private readonly TestDbContext _context;
        private readonly CustomerService _customerService;

        public CustomerServiceTests()
        {
            var options = new DbContextOptionsBuilder<TestDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

            _context = new TestDbContext(options);
            _context.Database.EnsureCreated();
            _customerService = new CustomerService(_context);
        }

        [Fact]
        public async Task CanPurchase_NonRegisteredCustomer_ThrowsInvalidOperation()
        {
            //Arrange
            int unexistingCustomerId = 999;
            decimal purchaseValue = 100.0M;
       

            //Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                _customerService.CanPurchase(unexistingCustomerId, purchaseValue));
            
            
        }

        [Fact]
        public async Task CanPurchase_PurchaseMoreThanOneTimeInAMonth_ReturnsFalse()
        {
            //Arrange
            var customerId = 1;
            decimal purchaseValue = 100.0M;

            var recentOrder = new Order
            {
                CustomerId = customerId,
                OrderDate = DateTime.UtcNow.AddDays(-29),
                Id = 1
            };
            _context.Orders.Add(recentOrder);
            await _context.SaveChangesAsync();

            //Act
            var canPurchase = await _customerService.CanPurchase(customerId, purchaseValue);

            //Assert
            Assert.False(canPurchase);
        }

        [Fact]
        public async Task CanPurchase_FirstPurchaseLessThan100_ReturnsFalse()
        {
            //Arrange
            var customer = new Customer
            {
               Id= 100,
               Name = "Teste",
               Orders = new List<Order>()
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();


            //Act
            var canPurchase = await _customerService.CanPurchase(customer.Id, 199.00M);

            //Assert
            Assert.False(canPurchase);

        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

    }
}
