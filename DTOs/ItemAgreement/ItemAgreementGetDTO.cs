using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovoUsoApi.Models.Enums;

namespace NovoUsoApi.DTOs.ItemAgreement
{
    public class ItemAgreementGetDTO
    {
        public int Id { get; set; }
        public AgreementStatus? Status { get; set; } = null;
        public DateTime? OwnerAcceptedAtUtc { get; set; }
        public DateTime? WinnerAcceptedAtUtc { get; set; }
        public DateTime? ClosedAtUtc { get; set; }
        public string? RejectionReason { get; set; }
        public int ItemId { get; set; }
        public int BidId { get; set; }
    }
}