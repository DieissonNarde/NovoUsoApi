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
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _context;

        public ItemRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<Item> AddAsync(Item item)
        {
            _context.Item.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Item> DeleteAsync(int id)
        {
            var item = await _context.Item.FindAsync(id);
            
            if(item == null)
            {
                return null;
            }

            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<List<Item>> GetAllAsync()
        {
            return await _context.Item.Where(x => x.Status == Models.Enums.ItemStatus.Published).ToListAsync();
        }

        public async Task<Item> GetByIdAsync(int id)
        {
            return await _context.Item.FindAsync(id);
        }

        public async Task<Item> UpdateAsync(Item item)
        {
            _context.Item.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}