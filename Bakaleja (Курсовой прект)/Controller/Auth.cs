using Bakaleja__Курсовой_прект_.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakaleja__Курсовой_прект_.Controller
{
    public class Auth : IAuth
    {
        private readonly GroceryDBContext _context;
        private ITovary _tovary;
        public Auth(ITovary tovary)
        {
            _context = new GroceryDBContext();
            _tovary = tovary;
        }
        public async Task<User> CreateUser()
        {
            User user = new User();
            if (_context.Users.Count()==0)
            {
                user.Login = "user_" + 1;
            }
            else
            {
                user.Login="user_" + (_context.Users.ToList().LastOrDefault().Id+1);
            }
            user.Salt = Guid.NewGuid().ToString();
            user.Password = Guid.NewGuid().ToString().Substring(0, 5);

            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<bool> TovaryCheck()
        {
            if (_context.Tovaries.Count()>0)
            {
                return true;
            }
            else
            {
                var user = await CreateUser();
                Tovary tovary = new Tovary
                {
                    User = user
                };
                _context.Tovaries.Add(tovary);
                await _context.SaveChangesAsync();
                return false;
            }
        }
        public async Task<IUser> Login(string login, string password, string text)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Login==login);
            if (user.Password == await _tovary.HashPassword(password, user.Salt))
            {
                var tovary = _context.Tovaries.Include("User").FirstOrDefault(t => t.User.Id==user.Id);
                var product = _context.Products.Include("User").FirstOrDefault(p => p.User.Id == user.Id);
                var shop = _context.Shops.Include("User").FirstOrDefault(s => s.User.Id==user.Id);

                if (tovary!=null)
                {
                    return (IUser)tovary;
                }
                else if (product!=null)
                {
                    return (IUser)product;
                }
                else if (shop!=null)
                {
                    return (IUser)shop;
                }

            }
            return null;
        }
    }

        
}
