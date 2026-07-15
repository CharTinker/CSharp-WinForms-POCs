using System;

namespace CSharpWinFormsPOCs._07_Caching.Models
{
    public class Customer
    {
        public string CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RetrievedAt { get; set; }
    }
}