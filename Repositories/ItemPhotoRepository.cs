using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovoUsoApi.Interfaces;
using NovoUsoApi.Models;

namespace NovoUsoApi.Repositories
{
    public class ItemPhotoRepository : IItemPhotoRepository
    {
        public Task<ItemPhoto> AddAsync(ItemPhoto itemPhoto)
        {
            throw new NotImplementedException();
        }

        public Task<ItemPhoto> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ItemPhoto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ItemPhoto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ItemPhoto> UpdateAsync(ItemPhoto itemPhoto)
        {
            throw new NotImplementedException();
        }
    }
}