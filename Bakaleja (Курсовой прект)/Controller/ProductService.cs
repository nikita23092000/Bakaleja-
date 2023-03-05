using Bakaleja__Курсовой_прект_.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakaleja__Курсовой_прект_.Controller
{
    public class ProductService : IService
    {
        private readonly GroceryDBContext _context;
        public static ProductService Instance { get => ProductServiceCreate.instance; }
        Auth auth;
        private ProductService()
        {
            _context = new GroceryDBContext();
            auth = new Auth(new Encrypt());
        }
        private class ProductServiceCreate
        {
            static ProductServiceCreate() { }
            internal static readonly ProductService instance = new ProductService();
        }

        public async Task<Product> GetProduct(User user)
        {
            var product = await _context.Products.Include("Clients").Include("Clients.Shops")
                .Include("User").FirstOrDefaultAsync(p=>p.User.Id == user.Id);
            return product;
        }
        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Products.Include("Clients").Include("Clients.Shops").Include("User")
                .ToListAsync();
        }           


        public async Task<ITovary> AddObject(ITovary tovary)
        {
            var user = await auth.CreateUser();

            Product newProduct = (Product)tovary;
            newProduct.User = user;

            _context.Products.Add(newProduct);
            int res = await _context.SaveChangesAsync();

            if (res==0)
            {
                throw new Exception();
            }
            return newProduct;
        }

        public async Task<ITovary> RemoveObject(int id)
        {
            return await _context.Products.Include("Clients").Include("Clients.Shop").FirstOrDefaultAsync(p=>p.Id == id);
        }

        public Task<ITovary> GetObject(int id)
        {
            throw new NotImplementedException();
        }
    }
}
