using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovoUsoApi.Models;

namespace NovoUsoApi.Interfaces
{
    public interface IItemRepository
    {
        Task<Item> GetByIdAsync(int id);
        Task<List<Item>> GetAllAsync();
        Task<Item> AddAsync(Item item);
        Task<Item> UpdateAsync(Item item);
        Task<Item> DeleteAsync(int id);
    }
}