using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakaleja__Курсовой_прект_.Model
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime Duration { get; set; }
        public Tovary Tovary { get; set; }
        

        public override string ToString()
        {
            return $"{Name} {Price}";
        }
    }
}
