using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovoUsoApi.Interfaces;
using NovoUsoApi.Models;

namespace NovoUsoApi.Repositories
{
    public class BidRepository : IBidRepository
    {
        public Task<Bid> AddAsync(Bid bid)
        {
            throw new NotImplementedException();
        }

        public Task<Bid> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Bid>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Bid> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Bid> UpdateAsync(Bid bid)
        {
            throw new NotImplementedException();
        }
    }
}