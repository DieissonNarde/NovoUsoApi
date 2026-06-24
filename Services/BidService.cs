using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovoUsoApi.DTOs.Bid;
using NovoUsoApi.DTOs.ItemAgreement;
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
        private readonly IItemAgreementRepository _itemAgreementRepository;

        public BidService(
            IBidRepository bidRepository,
            IItemRepository itemRepository,
            IUserRepository userRepository,
            IItemAgreementRepository itemAgreementRepository)
        {
            _bidRepository = bidRepository;
            _itemRepository = itemRepository;
            _userRepository = userRepository;
            _itemAgreementRepository = itemAgreementRepository;
        }
        
        public async Task<BidGetDTO> AddAsync(BidPostDTO bidPostDTO)
        {
            var user = await _userRepository.GetByIdAsync(bidPostDTO.UserId);
            if (user == null)
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
                UserId = createdBid.UserId,
                UserName = user.Name
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
                UserId = deletedBid.UserId,
                UserName = deletedBid.User?.Name ?? string.Empty
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
                UserId = bid.UserId,
                UserName = bid.User?.Name ?? string.Empty
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
                UserId = bid.UserId,
                UserName = bid.User?.Name ?? string.Empty
            };
        }

        public async Task<BidGetDTO> UpdateAsync(BidPutDTO bidPutDTO)
        {
            var existingBid = await _bidRepository.GetByIdAsync(bidPutDTO.Id);
            if (existingBid == null)
                throw new NotFoundException("Lance não encontrado.");

            existingBid.Date = DateTime.UtcNow;
            existingBid.Value = bidPutDTO.Value;
            existingBid.Description = bidPutDTO.Description;
            existingBid.Status = bidPutDTO.Status;
            existingBid.ProposalType = bidPutDTO.ProposalType;

            var updatedBid = await _bidRepository.UpdateAsync(existingBid);
            if (updatedBid == null)
                return null;

            if (bidPutDTO.Status == BidStatus.Accepted)
            {
                var item = await _itemRepository.GetByIdAsync(existingBid.ItemId);
                if (item != null)
                {
                    item.Status = ItemStatus.AwaitingAgreement;
                    await _itemRepository.UpdateAsync(item);
                }

                var existingAgreement = (await _itemAgreementRepository.GetAllAsync())
                    .FirstOrDefault(a => a.ItemId == existingBid.ItemId);

                if (existingAgreement == null)
                {
                    await _itemAgreementRepository.AddAsync(new ItemAgreement
                    {
                        Status = AgreementStatus.PendingWinner,
                        OwnerAcceptedAtUtc = DateTime.UtcNow,
                        WinnerAcceptedAtUtc = null,
                        CreatedAtUtc = DateTime.UtcNow,
                        ClosedAtUtc = null,
                        RejectionReason = null,
                        ItemId = existingBid.ItemId,
                        BidId = existingBid.Id
                    });
                }
            }

            return new BidGetDTO
            {
                Id = updatedBid.Id,
                Date = updatedBid.Date,
                Value = updatedBid.Value,
                Description = updatedBid.Description,
                Status = updatedBid.Status,
                ProposalType = updatedBid.ProposalType,
                ItemId = updatedBid.ItemId,
                UserId = updatedBid.UserId,
                UserName = updatedBid.User?.Name ?? string.Empty
            };
        }
    }
}
