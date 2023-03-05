using Bakaleja__Курсовой_прект_.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakaleja__Курсовой_прект_.Controller
{
    public interface IService
    {
        Task<ITovary> AddObject(ITovary tovary);
        Task<ITovary> RemoveObject(int id);
        Task<ITovary> GetObject(int id);
    }
}
