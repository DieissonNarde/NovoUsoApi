using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovoUsoApi.Interfaces;
using NovoUsoApi.Models;

namespace NovoUsoApi.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        public Task<Address> AddAsync(Address bid)
        {
            throw new NotImplementedException();
        }

        public Task<Address> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Address>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Address> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Address> UpdateAsync(Address bid)
        {
            throw new NotImplementedException();
        }
    }
}