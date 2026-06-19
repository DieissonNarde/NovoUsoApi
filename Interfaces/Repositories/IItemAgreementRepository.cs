using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovoUsoApi.Models;

namespace NovoUsoApi.Interfaces
{
    public interface IItemAgreementRepository
    {
        Task<ItemAgreement> GetByIdAsync(int id);
        Task<List<ItemAgreement>> GetAllAsync();
        Task<ItemAgreement> AddAsync(ItemAgreement itemAgreement);
        Task<ItemAgreement> UpdateAsync(ItemAgreement itemAgreement);
        Task<ItemAgreement> DeleteAsync(int id);
    }
}