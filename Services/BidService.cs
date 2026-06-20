using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovoUsoApi.DTOs.Bid;
using NovoUsoApi.Interfaces;
using NovoUsoApi.Interfaces.Services;
using NovoUsoApi.Models;

namespace NovoUsoApi.Services
{
    public class BidService : IBidService
    {
        private readonly IBidRepository _bidRepository;
        public BidService(IBidRepository bidRepository)
        {
            _bidRepository = bidRepository;
        }
        
        public async Task<BidGetDTO> AddAsync(BidPostDTO bidPostDTO)
        {
            var bid = new Bid
            {
                Date = bidPostDTO.Date,
                Value = bidPostDTO.Value,
                Description = bidPostDTO.Description,
                Status = bidPostDTO.Status,
                ProposalType = bidPostDTO.ProposalType,
                ItemId = bidPostDTO.ItemId,
                UserId = bidPostDTO.UserId
            };
            var createdBid = await _bidRepository.AddAsync(bid);
            return new BidGetDTO
            {
                Id = createdBid.Id,
                Date = createdBid.Date,
                Value = createdBid.Value,
                Description = createdBid.Description,
                Status = createdBid.Status,
                ProposalType = createdBid.ProposalType,
                ItemId = createdBid.ItemId,
                UserId = createdBid.UserId
            };
        }

        public async Task<BidGetDTO> DeleteAsync(int id)
        {
            var deletedBid = await _bidRepository.DeleteAsync(id);
            return new BidGetDTO
            {
                Id = deletedBid.Id,
                Date = deletedBid.Date,
                Value = deletedBid.Value,
                Description = deletedBid.Description,
                Status = deletedBid.Status,
                ProposalType = deletedBid.ProposalType,
                ItemId = deletedBid.ItemId,
                UserId = deletedBid.UserId
            };
        }

        public async Task<List<BidGetDTO>> GetAllAsync()
        {
            var bids = await _bidRepository.GetAllAsync();
            return bids.Select(bid => new BidGetDTO
            {
                Id = bid.Id,
                Date = bid.Date,
                Value = bid.Value,
                Description = bid.Description,
                Status = bid.Status,
                ProposalType = bid.ProposalType,
                ItemId = bid.ItemId,
                UserId = bid.UserId
            }).ToList();
        }

        public async Task<BidGetDTO> GetByIdAsync(int id)
        {
            var user = await _bidRepository.GetByIdAsync(id);
            if (user == null)
                return null;
            return new BidGetDTO
            {
                Id = user.Id,
                Date = user.Date,
                Value = user.Value,
                Description = user.Description,
                Status = user.Status,
                ProposalType = user.ProposalType,
                ItemId = user.ItemId,
                UserId = user.UserId
            };
        }

        public async Task<BidGetDTO> UpdateAsync(BidPutDTO bidPutDTO)
        {
            var bid = new Bid
            {
                Id = bidPutDTO.Id,
                Date = bidPutDTO.Date,
                Value = bidPutDTO.Value,
                Description = bidPutDTO.Description,
                Status = bidPutDTO.Status,
                ProposalType = bidPutDTO.ProposalType,
                ItemId = bidPutDTO.ItemId,
                UserId = bidPutDTO.UserId
            };
            
            var updatedBid = await _bidRepository.UpdateAsync(bid);
            if (updatedBid == null)
                return null;
            return new BidGetDTO
            {
                Id = updatedBid.Id,
                Date = updatedBid.Date,
                Value = updatedBid.Value,
                Description = updatedBid.Description,
                Status = updatedBid.Status,
                ProposalType = updatedBid.ProposalType,
                ItemId = updatedBid.ItemId,
                UserId = updatedBid.UserId
            };
        }
    }
}