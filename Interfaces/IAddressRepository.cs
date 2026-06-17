using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovoUsoApi.Models;

namespace NovoUsoApi.Interfaces
{
    public interface IAddressRepository
    {
        Task<Address> GetByIdAsync(int id);
        Task<List<Address>> GetAllAsync();
        Task<Address> AddAsync(Address bid);
        Task<Address> UpdateAsync(Address bid);
        Task<Address> DeleteAsync(int id);
    }
}