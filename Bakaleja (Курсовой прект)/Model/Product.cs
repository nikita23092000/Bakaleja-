using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakaleja__Курсовой_прект_.Model
{
    public enum ProductType
    {
        Milk,
        Bread
    }
    public class Product : ITovary
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Count { get; set; }
        public ProductType type { get; set; }
        public User User { get; set; }
        public ICollection< Client> Clients { get; set; }
        public override string ToString()
        {
            return $"{Name} {Price} {Count}";

        }

        public string HashPassword(string password, string salt)
        {
            throw new NotImplementedException();
        }

        Task<string> ITovary.HashPassword(string password, string salt)
        {
            throw new NotImplementedException();
        }
    }
}
