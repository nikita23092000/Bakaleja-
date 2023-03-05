using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakaleja__Курсовой_прект_.Model
{
    public interface ITovary
    {
        Task<string> HashPassword(string password, string salt);
    }
}
