using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakaleja__Курсовой_прект_.Model
{
    public class DataService
    {
        private GroceryDBContext _context;
        private DataService()
        {
            _context = new GroceryDBContext();
        }

        public static DataService Instance { get => DataServiceCreate.instance; }
        private class DataServiceCreate
        {
            static DataServiceCreate() { }
            internal static readonly DataService instance = new DataService();
        }

        public async Task<List<Tovary>> GetAllTovariesAsync()
        {
            return await _context.Tovaries.Include("Services").ToListAsync();
        }

        public async Task<Tovary> GetTovaryAsync(string name)
        {
            return await _context.Tovaries.Include("Service").FirstOrDefaultAsync(t=>t.Name==name);
        }

        public async Task<bool> AddServiceAsync(Service service)
        {
            _context.Services.Add(service);
            int res = await _context.SaveChangesAsync();
            if (res > 0)
            {
                return true;
            }
            return false;
        }

        public Service GetLastService()
        {
            return _context.Services.Last();
        }
    } 
}
