using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovoUsoApi.DTOs.Bid;
using NovoUsoApi.DTOs.Item;
using NovoUsoApi.DTOs.ItemAgreement;
using NovoUsoApi.Interfaces;
using NovoUsoApi.Interfaces.Services;
using NovoUsoApi.Middleawre.Errors;
using NovoUsoApi.Models;
using NovoUsoApi.Models.Enums;

namespace NovoUsoApi.Services
{
    public class ItemAgreementService : IItemAgreementService
    {
        private readonly IItemAgreementRepository _itemAgreementRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IBidRepository _bidRepository;

        public ItemAgreementService(IItemAgreementRepository itemAgreementRepository, IItemRepository itemRepository, IBidRepository bidRepository)
        {
            _itemAgreementRepository = itemAgreementRepository;
            _itemRepository = itemRepository;
            _bidRepository = bidRepository;
        }

        public async Task<ItemAgreementGetDTO> AddAsync(ItemAgreementPostDTO itemAgreementPostDTO)
        {
            if (await _itemRepository.GetByIdAsync(itemAgreementPostDTO.ItemId) == null)
                throw new NotFoundException("Item não encrontado.");

            if (await _bidRepository.GetByIdAsync(itemAgreementPostDTO.BidId) == null)
                throw new NotFoundException("Lance não encrontado.");
            
            var itemAgreement = new ItemAgreement
            {
                Status = AgreementStatus.PendingBoth,
                OwnerAcceptedAtUtc = itemAgreementPostDTO.OwnerAcceptedAtUtc,
                WinnerAcceptedAtUtc = itemAgreementPostDTO.WinnerAcceptedAtUtc,
                CreatedAtUtc = DateTime.UtcNow,
                ClosedAtUtc = itemAgreementPostDTO.ClosedAtUtc,
                RejectionReason = itemAgreementPostDTO.RejectionReason,
                ItemId = itemAgreementPostDTO.ItemId,
                BidId = itemAgreementPostDTO.BidId
            };

            var createdItemAgreement = await _itemAgreementRepository.AddAsync(itemAgreement);
            return new ItemAgreementGetDTO
            {
                Status = createdItemAgreement.Status,
                OwnerAcceptedAtUtc = createdItemAgreement.OwnerAcceptedAtUtc,
                WinnerAcceptedAtUtc = createdItemAgreement.WinnerAcceptedAtUtc,
                CreatedAtUtc = createdItemAgreement.CreatedAtUtc,
                ClosedAtUtc = createdItemAgreement.ClosedAtUtc,
                RejectionReason = createdItemAgreement.RejectionReason,
                ItemId = createdItemAgreement.ItemId,
                BidId = createdItemAgreement.BidId
            };
        }

        public async Task<List<ItemAgreementGetDTO>> GetAllAsync()
        {
            var itemAgreements = await _itemAgreementRepository.GetAllAsync();
            return itemAgreements.Select(itemAgreement => new ItemAgreementGetDTO
            {
                Id = itemAgreement.Id,
                Status = itemAgreement.Status,
                OwnerAcceptedAtUtc = itemAgreement.OwnerAcceptedAtUtc,
                WinnerAcceptedAtUtc = itemAgreement.WinnerAcceptedAtUtc,
                CreatedAtUtc = itemAgreement.CreatedAtUtc,
                ClosedAtUtc = itemAgreement.ClosedAtUtc,
                RejectionReason = itemAgreement.RejectionReason,
                ItemId = itemAgreement.ItemId,
                BidId = itemAgreement.BidId
            }).ToList();
        }

        public async Task<ItemAgreementGetDetailDTO> GetByIdAsync(int id)
        {
            var itemAgreement = await _itemAgreementRepository.GetByIdAsync(id);
            if (itemAgreement == null)
            {
                throw new NotFoundException("Contrato de Item não encontrado.");
            }

            return new ItemAgreementGetDetailDTO
            {
                Id = itemAgreement.Id,
                Status = itemAgreement.Status,
                OwnerAcceptedAtUtc = itemAgreement.OwnerAcceptedAtUtc,
                WinnerAcceptedAtUtc = itemAgreement.WinnerAcceptedAtUtc,
                CreatedAtUtc = itemAgreement.CreatedAtUtc,
                ClosedAtUtc = itemAgreement.ClosedAtUtc,
                RejectionReason = itemAgreement.RejectionReason,
                Item = new ItemGetDTO 
                {
                    Id = itemAgreement.Item.Id,
                    Title = itemAgreement.Item.Title,
                    Description = itemAgreement.Item.Description,
                    Quantity = itemAgreement.Item.Quantity,
                    ZipCode = itemAgreement.Item.ZipCode,
                    State = itemAgreement.Item.State,
                    City = itemAgreement.Item.City,
                    Neighborhood = itemAgreement.Item.Neighborhood,
                    Street = itemAgreement.Item.Street,
                    Complement = itemAgreement.Item.Complement,
                    TypeOffer = itemAgreement.Item.TypeOffer,
                    Value = itemAgreement.Item.Value,
                    UserId = itemAgreement.Item.UserId,
                },
                Bid = new BidGetDTO
                {
                    Id = itemAgreement.Bid.Id,
                    Value = itemAgreement.Bid.Value,
                    UserId = itemAgreement.Bid.UserId,
                }
            };
        }

        public async Task<ItemAgreementGetDTO> UpdateAsync(ItemAgreementPutDTO itemAgreementPutDTO)
        {
            if (await _itemAgreementRepository.GetByIdAsync(itemAgreementPutDTO.Id) == null)
                throw new NotFoundException("Contrato de Item não encontrado.");

            var itemAgreement = new ItemAgreement
            {
                Id = itemAgreementPutDTO.Id,
                Status = itemAgreementPutDTO.Status,
                OwnerAcceptedAtUtc = itemAgreementPutDTO.OwnerAcceptedAtUtc,
                WinnerAcceptedAtUtc = itemAgreementPutDTO.WinnerAcceptedAtUtc,
                ClosedAtUtc = itemAgreementPutDTO.ClosedAtUtc,
                RejectionReason = itemAgreementPutDTO.RejectionReason
            };

            var updatedItemAgreement = await _itemAgreementRepository.UpdateAsync(itemAgreement);
            return new ItemAgreementGetDTO
            {
                Id = updatedItemAgreement.Id,
                Status = updatedItemAgreement.Status,
                OwnerAcceptedAtUtc = updatedItemAgreement.OwnerAcceptedAtUtc,
                WinnerAcceptedAtUtc = updatedItemAgreement.WinnerAcceptedAtUtc,
                ClosedAtUtc = updatedItemAgreement.ClosedAtUtc,
                RejectionReason = updatedItemAgreement.RejectionReason
            };
        }
    }
}