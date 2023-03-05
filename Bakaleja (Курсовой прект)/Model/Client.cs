using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakaleja__Курсовой_прект_.Model
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Amount { get; set; }
        public User User { get; set; }
        public bool IsDelete { get; set; }
        
        public ICollection<Shop> Shops { get; set; }
    }
}
