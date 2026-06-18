using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
            return await _context.Address.ToListAsync();
        }

        public async Task<Address> GetByIdAsync(int id)
        {
            return await _context.Address.FindAsync(id);
        }

        public async Task<Address> UpdateAsync(Address address)
        {
            _context.Address.Update(address);
            await _context.SaveChangesAsync();
            return address;
        }
    }
}