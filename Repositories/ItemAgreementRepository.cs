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
    public class ItemAgreementRepository : IItemAgreementRepository
    {
        private readonly AppDbContext _context;

        public ItemAgreementRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ItemAgreement> AddAsync(ItemAgreement itemAgreement)
        {
            _context.ItemAgreement.Add(itemAgreement);
            await _context.SaveChangesAsync();
            return itemAgreement;
        }

        public async Task<ItemAgreement> DeleteAsync(int id)
        {
            var itemAgreement = await _context.ItemAgreement.FindAsync(id);
            
            if(itemAgreement == null)
            {
                return null;
            }

            await _context.SaveChangesAsync();
            return itemAgreement;
        }

        public async Task<List<ItemAgreement>> GetAllAsync()
        {
            return await _context.ItemAgreement.ToListAsync();
        }

        public async Task<ItemAgreement> GetByIdAsync(int id)
        {
            return await _context.ItemAgreement.FindAsync(id);
        }

        public async Task<ItemAgreement> UpdateAsync(ItemAgreement itemAgreement)
        {
            _context.ItemAgreement.Update(itemAgreement);
            await _context.SaveChangesAsync();
            return itemAgreement;
        }
    }
}