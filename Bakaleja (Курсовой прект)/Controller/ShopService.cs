using Bakaleja__Курсовой_прект_.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakaleja__Курсовой_прект_.Controller
{
    public class ShopService
    {
        private readonly GroceryDBContext _context;
        public static ShopService Instance { get => ShopServiceCreate.instance; }
        private ShopService()
        {
            _context = new GroceryDBContext();
        }
        private class ShopServiceCreate
        {
            static ShopServiceCreate() { }
            internal static readonly ShopService instance = new ShopService();
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Products.Include("Clients").Include("Clients.Shops").ToListAsync();
        }

        public async Task<List<Shop>> GetTodayShopIsActive(Product product)
        {
            return (await _context.Products.Include("Clients").Include("Clients.Shops").FirstOrDefaultAsync(p => p.Id==product.Id))
                .Clients.SelectMany(s => s.Shops).Where(s => s.IsActive && s.DateOfStart.Day == DateTime.Now.Day).ToList();
        }
        public async Task<List<Shop>> GetTodayShopIsDone(Product product)
        {
            return (await _context.Products.Include("Clients").Include("Clients.Shops").FirstOrDefaultAsync(p => p.Id==product.Id))
                .Clients.SelectMany(s => s.Shops).Where(s => s.IsActive && s.DateOfStart.Day == DateTime.Now.Day).ToList();
        }

        public async Task<bool> TransferClientToProduct(int productIdTo, int productId, Client client)
        {
            var productTo = _context.Products.Include("Clients").FirstOrDefault(p => p.Id==productIdTo);
            var product = _context.Products.Include("Clients").FirstOrDefault(p=>p.Id==productId);
            productTo.Clients.Add(client);
            product.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
