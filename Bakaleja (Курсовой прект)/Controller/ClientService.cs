using Bakaleja__Курсовой_прект_.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakaleja__Курсовой_прект_.Controller
{
    public class ClientService : IService
    {
        private readonly GroceryDBContext _context;
        public static ClientService Instance { get => ClientServiceCreate.instance; }
        private ClientService()
        {
            _context = new GroceryDBContext();
        }
        private class ClientServiceCreate
        {
            static ClientServiceCreate() { }
            internal static readonly ClientService instance = new ClientService();
        }

        public async Task<ITovary> AddObject(ITovary tovary)
        {
            Client newClient = (Client)tovary;
            _context.Products.Include("Clients").FirstOrDefault(p=>p.Id==1).Clients.Add(newClient);
            await _context.SaveChangesAsync();
            return (ITovary)newClient;
        }

        public async Task<bool> AddShop(Shop action, int clientId)
        {
            (await _context.Clients.Include("Shops").FirstOrDefaultAsync(c => c.Id==clientId)).Shops.Add(action);
            int res = await _context.SaveChangesAsync();
            if (res == 0)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> UpdateShopStatus(Shop action)
        {
            var user = (await _context.Products.Include("Clients").Include("Clients.Shops")
                .Include("User").FirstOrDefaultAsync(p=>p.Clients.Any(c=>c.Shops.Any(s=>s.Id==action.Id))));

            var selectedShop = await _context.Shops.FirstOrDefaultAsync(s=>s.Id== action.Id);
            selectedShop.IsActive = action.IsActive;
            selectedShop.Text = action.Text;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveClient(int clientId)
        {
            var user = (await _context.Products.Include("Clients").Include("User")
                .FirstOrDefaultAsync(p => p.Clients.Any(c => c.Id==clientId))).User;

            var client = await _context.Clients.Include("Tovaries").FirstOrDefaultAsync(c=>c.Id==clientId);

            client.IsDelete = true;
            await _context.SaveChangesAsync();      
            return true;
        }

        public async Task<bool> RemoveShop(int shopId)
        {
            var user = (await _context.Products.Include("Clients").Include("Clients.Shops")
                .Include("User").FirstOrDefaultAsync(p => p.Clients.Any(c => c.Shops.Any(s => s.Id==shopId)))).User;

            var action = await _context.Shops.FirstOrDefaultAsync(s=>s.Id== shopId);

            action.IsActive = true;
            await _context.SaveChangesAsync();
            return true;
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
