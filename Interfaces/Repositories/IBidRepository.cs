using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovoUsoApi.Models;

namespace NovoUsoApi.Interfaces
{
    public interface IBidRepository
    {
        Task<Bid> GetByIdAsync(int id);
        Task<List<Bid>> GetAllAsync();
        Task<Bid> AddAsync(Bid bid);
        Task<Bid> UpdateAsync(Bid bid);
        Task<Bid> DeleteAsync(int id);
    }
}