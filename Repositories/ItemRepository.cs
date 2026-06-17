using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovoUsoApi.Interfaces;
using NovoUsoApi.Models;

namespace NovoUsoApi.Repositories
{
    public class ItemRepository : IItemRepository
    {
        public Task<Item> AddAsync(Item item)
        {
            throw new NotImplementedException();
        }

        public Task<Item> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Item>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Item> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Item> UpdateAsync(Item item)
        {
            throw new NotImplementedException();
        }
    }
}