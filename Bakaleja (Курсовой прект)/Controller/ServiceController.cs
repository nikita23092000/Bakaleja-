using Bakaleja__Курсовой_прект_.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakaleja__Курсовой_прект_.Controller
{
    public class ServiceController : IService
    {
        private readonly GroceryDBContext _context;
        public static ServiceController Instance { get => ServiceControllerCreate.instance; }
        private ServiceController()
        {
            _context = new GroceryDBContext();
        }
        private class ServiceControllerCreate
        {
            static ServiceControllerCreate() { }
            internal static readonly ServiceController instance = new ServiceController();
        }

        public async Task<ITovary> AddObject(ITovary tovary)
        {
            Service newService = (Service)tovary;
            _context.Services.Add(newService);
            int res = await _context.SaveChangesAsync();
            if(res == 0)
            {
                throw new Exception();
            }
            return (ITovary)newService;
        }

        public Task<ITovary> RemoveObject(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ITovary> GetObject(int id)
        {
            throw new NotImplementedException();
        }
    }
}
