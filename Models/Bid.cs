using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovoUsoApi.Models.Enums;

namespace NovoUsoApi.Models
{
    public class Bid
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public BidStatus Status { get; set; }

        public ProposalType ProposalType { get; set; }

        public Guid ItemId { get; set; }
        public Item Item { get; set; } = null!;

        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
    }
}