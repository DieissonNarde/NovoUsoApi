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
    public class ItemPhotoRepository : IItemPhotoRepository
    {
        private readonly AppDbContext _context;

        public ItemPhotoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ItemPhoto> AddAsync(ItemPhoto itemPhoto)
        {
            _context.ItemPhoto.Add(itemPhoto);
            await _context.SaveChangesAsync();
            return itemPhoto;
        }

        public async Task<ItemPhoto> DeleteAsync(int id)
        {
            var itemPhoto = await _context.ItemPhoto.FindAsync(id);
            
            if(itemPhoto == null)
            {
                return null;
            }

            await _context.SaveChangesAsync();
            return itemPhoto;
        }

        public async Task<List<ItemPhoto>> GetAllAsync()
        {
            return await _context.ItemPhoto.ToListAsync();
        }

        public async Task<ItemPhoto> GetByIdAsync(int id)
        {
            return await _context.ItemPhoto.FindAsync(id);
        }

        public async Task<ItemPhoto> UpdateAsync(ItemPhoto itemPhoto)
        {
            _context.ItemPhoto.Update(itemPhoto);
            await _context.SaveChangesAsync();
            return itemPhoto;
        }
    }
}