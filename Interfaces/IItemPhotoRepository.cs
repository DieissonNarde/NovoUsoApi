using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovoUsoApi.Models;

namespace NovoUsoApi.Interfaces
{
    public interface IItemPhotoRepository
    {
        Task<ItemPhoto> GetByIdAsync(int id);
        Task<List<ItemPhoto>> GetAllAsync();
        Task<ItemPhoto> AddAsync(ItemPhoto itemPhoto);
        Task<ItemPhoto> UpdateAsync(ItemPhoto itemPhoto);
        Task<ItemPhoto> DeleteAsync(int id);
    }
}