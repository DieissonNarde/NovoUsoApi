using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovoUsoApi.Interfaces;
using NovoUsoApi.Models;

namespace NovoUsoApi.Repositories
{
    public class ItemAgreementRepository : IItemAgreementRepository
    {
        public Task<ItemAgreement> AddAsync(ItemAgreement itemAgreement)
        {
            throw new NotImplementedException();
        }

        public Task<ItemAgreement> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ItemAgreement>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ItemAgreement> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ItemAgreement> UpdateAsync(ItemAgreement itemAgreement)
        {
            throw new NotImplementedException();
        }
    }
}