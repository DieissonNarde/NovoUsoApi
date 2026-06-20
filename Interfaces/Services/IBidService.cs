using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovoUsoApi.DTOs.Bid;

namespace NovoUsoApi.Interfaces.Services
{
    public interface IBidService
    {
        Task<BidGetDTO> GetByIdAsync(int id);
        Task<List<BidGetDTO>> GetAllAsync();
        Task<BidGetDTO> AddAsync(BidPostDTO bidPostDTO);
        Task<BidGetDTO> UpdateAsync(BidPutDTO bidPutDTO);
        Task<BidGetDTO> DeleteAsync(int id);
    }
}