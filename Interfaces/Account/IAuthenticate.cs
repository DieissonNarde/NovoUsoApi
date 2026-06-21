using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovoUsoApi.Models;

namespace NovoUsoApi.Interfaces.Account
{
    public interface IAuthenticate
    {
        public string GenerateToken(int id, string email);
        Task<User> GetUserByEmail(string email);
        Task<bool> UserExists(string email);
    }
}