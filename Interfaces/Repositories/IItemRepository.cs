using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovoUsoApi.Models;
using NovoUsoApi.Pagination;

namespace NovoUsoApi.Interfaces
{
    public interface IItemRepository
    {
        Task<Item> GetByIdAsync(int id);
        Task<PagedList<Item>> GetAllAsync(int pageNumber, int pageSize);
        Task<Item> AddAsync(Item item);
        Task<Item> UpdateAsync(Item item);
        Task<Item> DeleteAsync(int id);
    }
}