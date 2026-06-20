using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovoUsoApi.DTOs.ItemAgreement;
using NovoUsoApi.Interfaces;
using NovoUsoApi.Interfaces.Services;

namespace NovoUsoApi.Services
{
    public class ItemAgreementService : IItemAgreementService
    {
        private readonly IItemAgreementRepository _itemAgreementRepository;
        public ItemAgreementService(IItemAgreementRepository itemAgreementRepository)
        {
            _itemAgreementRepository = itemAgreementRepository;
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
                ClosedAtUtc = itemAgreement.ClosedAtUtc,
                RejectionReason = itemAgreement.RejectionReason,
                ItemId = itemAgreement.ItemId,
                BidId = itemAgreement.BidId
            }).ToList();
        }

        public async Task<ItemAgreementGetDTO> GetByIdAsync(int id)
        {
            var itemAgreement = await _itemAgreementRepository.GetByIdAsync(id);
            if (itemAgreement == null)
            {
                return null;
            }

            return new ItemAgreementGetDTO
            {
                Id = itemAgreement.Id,
                Status = itemAgreement.Status,
                OwnerAcceptedAtUtc = itemAgreement.OwnerAcceptedAtUtc,
                WinnerAcceptedAtUtc = itemAgreement.WinnerAcceptedAtUtc,
                ClosedAtUtc = itemAgreement.ClosedAtUtc,
                RejectionReason = itemAgreement.RejectionReason,
                ItemId = itemAgreement.ItemId,
                BidId = itemAgreement.BidId
            };
        }
    }
}