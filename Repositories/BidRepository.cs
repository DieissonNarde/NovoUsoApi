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
    public class BidRepository : IBidRepository
    {
        private readonly AppDbContext _context;

        public BidRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Bid> AddAsync(Bid bid)
        {
            _context.Bid.Add(bid);
            await _context.SaveChangesAsync();
            return bid;
        }

        public async Task<Bid> DeleteAsync(int id)
        {
            var bid = await _context.Bid.FindAsync(id);
            
            if(bid == null)
            {
                return null;
            }

            await _context.SaveChangesAsync();
            return bid;
        }

        public async Task<List<Bid>> GetAllAsync()
        {
            return await _context.Bid
                .Include(x => x.User)
                .Include(x => x.Item)
                .ToListAsync();
        }

        public async Task<Bid> GetByIdAsync(int id)
        {
            return await _context.Bid
                .Include(x => x.User)
                .Include(x => x.Item)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Bid> UpdateAsync(Bid bid)
        {
            _context.Bid.Update(bid);
            await _context.SaveChangesAsync();
            return bid;
        }
    }
}
