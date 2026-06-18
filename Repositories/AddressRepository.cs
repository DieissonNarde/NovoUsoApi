using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovoUsoApi.Data;
using NovoUsoApi.Interfaces;
using NovoUsoApi.Models;

namespace NovoUsoApi.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext _context;

        public AddressRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Address> AddAsync(Address address)
        {
            _context.Address.Add(address);
            await _context.SaveChangesAsync();
            return address;
        }

        public async Task<Address> DeleteAsync(int id)
        {
            var address = await _context.Address.FindAsync(id);
            
            if(address == null)
            {
                return null;
            }

            await _context.SaveChangesAsync();
            return address;
        }

        public async Task<List<Address>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Address> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Address> UpdateAsync(Address address)
        {
            throw new NotImplementedException();
        }
    }
}