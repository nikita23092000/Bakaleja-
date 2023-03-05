using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakaleja__Курсовой_прект_.Model
{
    public enum ShopType
    {
        Call,
        Bread
    }
    public class Shop : ITovary
    {
        public int Id { get; set; }
        //public ShopType shopType  { get; set; }
        public string Text { get; set; }
        public DateTime DateOfStart { get; set; }
        public DateTime DateOfCreate { get; set; }
        public DateTime DateOfEnd { get; set; }
        public bool IsActive { get; set; }        
        public Client Client { get; set; }
        public Service Service { get; set; }
        public User User { get; set; }
        

        public override string ToString()
        {
            return $"{DateOfStart} {DateOfEnd} {IsActive}";
        }

        Task<string> ITovary.HashPassword(string password, string salt)
        {
            throw new NotImplementedException();
        }
    }
}
