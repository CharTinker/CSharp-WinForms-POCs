using CSharpWinFormsPOCs._07_Caching.Models;
using System;
using System.Threading.Tasks;

namespace CSharpWinFormsPOCs._07_Caching.Repositories
{
    public class SlowCustomerRepository : ICustomerRepository
    {
        public async Task<Customer> GetCustomerAsync(
            string customerId)
        {
            // Simulate a slow database or API call.
            await Task.Delay(2000);

            return new Customer
            {
                CustomerId = customerId,
                Name = "Customer " + customerId,
                Email = "customer" + customerId + "@example.com",
                RetrievedAt = DateTime.Now
            };
        }
    }
}