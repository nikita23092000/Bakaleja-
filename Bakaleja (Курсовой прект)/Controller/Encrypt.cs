﻿using Bakaleja__Курсовой_прект_.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakaleja__Курсовой_прект_.Controller
{
    public class Encrypt : ITovary
    {
        public async Task<string> HashPassword(string password, string salt)
        {
            string res = "";
            await Task.Run(() =>
            {
                res = Convert.ToBase64String(Pbkdf2.Pbkdf2.HashData("SHA512", Encoding.ASCII.GetBytes(password), Encoding.ASCII.GetBytes(salt), 350000, 64));
            });
            return res;
        }
    }
}
