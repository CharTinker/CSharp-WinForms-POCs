using CSharpWinFormsPOCs._07_Caching.Models;
using System.Threading.Tasks;

namespace CSharpWinFormsPOCs._07_Caching.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomerAsync(string customerId);
    }
}