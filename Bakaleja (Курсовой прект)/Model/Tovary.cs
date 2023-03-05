using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakaleja__Курсовой_прект_.Model
{    

    public class Tovary
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
        public ICollection<Service> Services { get; set; } = new List<Service>();

        

        public override string ToString()
        {
            return Name;
        }
    }
}
