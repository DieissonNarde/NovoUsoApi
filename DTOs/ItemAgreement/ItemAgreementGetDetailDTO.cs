using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovoUsoApi.DTOs.Bid;
using NovoUsoApi.DTOs.Item;
using NovoUsoApi.Models.Enums;

namespace NovoUsoApi.DTOs.ItemAgreement
{
    public class ItemAgreementGetDetailDTO
    {
        public int Id { get; set; }
        public AgreementStatus Status { get; set; }
        public DateTime? OwnerAcceptedAtUtc { get; set; }
        public DateTime? WinnerAcceptedAtUtc { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public DateTime? ClosedAtUtc { get; set; }
        public string? RejectionReason { get; set; }
        public ItemGetDTO Item { get; set; }
        public BidGetDTO Bid { get; set; }
    }
}