using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovoUsoApi.DTOs.Bid;
using NovoUsoApi.Interfaces;
using NovoUsoApi.Interfaces.Services;
using NovoUsoApi.Middleawre.Errors;
using NovoUsoApi.Models;
using NovoUsoApi.Models.Enums;

namespace NovoUsoApi.Services
{
    public class BidService : IBidService
    {
        private readonly IBidRepository _bidRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IUserRepository _userRepository;

        public BidService(IBidRepository bidRepository, IItemRepository itemRepository, IUserRepository userRepository)
        {
            _bidRepository = bidRepository;
            _itemRepository = itemRepository;
            _userRepository = userRepository;
        }
        
        public async Task<BidGetDTO> AddAsync(BidPostDTO bidPostDTO)
        {
            if (await _userRepository.GetByIdAsync(bidPostDTO.UserId) == null)
                throw new NotFoundException("Usuário não encrontado.");

            if (await _itemRepository.GetByIdAsync(bidPostDTO.ItemId) == null)
                throw new NotFoundException("Item não encrontado.");

            var bid = new Bid
            {
                Date = DateTime.UtcNow,
                Value = bidPostDTO.Value,
                Description = bidPostDTO.Description,
                Status = BidStatus.Sent,
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
            if (deletedBid == null)
                throw new NotFoundException("Lance não encontrado.");
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
            var bid = await _bidRepository.GetByIdAsync(id);
            if (bid == null)
                throw new NotFoundException("Lance não encontrado.");
            return new BidGetDTO
            {
                Id = bid.Id,
                Date = bid.Date,
                Value = bid.Value,
                Description = bid.Description,
                Status = bid.Status,
                ProposalType = bid.ProposalType,
                ItemId = bid.ItemId,
                UserId = bid.UserId
            };
        }

        public async Task<BidGetDTO> UpdateAsync(BidPutDTO bidPutDTO)
        {
            if (await _bidRepository.GetByIdAsync(bidPutDTO.Id) == null)
                throw new NotFoundException("Lance não encontrado.");
            
            var bid = new Bid
            {
                Id = bidPutDTO.Id,
                Date = DateTime.UtcNow,
                Value = bidPutDTO.Value,
                Description = bidPutDTO.Description,
                Status = bidPutDTO.Status,
                ProposalType = bidPutDTO.ProposalType
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
                ProposalType = updatedBid.ProposalType
            };
        }
    }
}