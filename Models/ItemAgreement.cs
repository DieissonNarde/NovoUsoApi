using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovoUsoApi.Models.Enums;

namespace NovoUsoApi.Models
{
    public class ItemAgreement
    {
         public Guid ItemId { get; set; }
        public Item Item { get; set; } = null!;

        public Guid WinningBidId { get; set; }
        public Bid WinningBid { get; set; } = null!;

        public AgreementStatus Status { get; set; } = AgreementStatus.PendingBoth;

        public DateTime? OwnerAcceptedAtUtc { get; set; }
        public DateTime? WinnerAcceptedAtUtc { get; set; }
        public DateTime? ClosedAtUtc { get; set; }

        public string? RejectionReason { get; set; }
    }
}