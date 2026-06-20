using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovoUsoApi.Models.Enums;

namespace NovoUsoApi.DTOs.Bid
{
    public class BidGetDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Value { get; set; } = null!;
        public string Description { get; set; } = null!;
        public BidStatus? Status { get; set; }
        public ProposalType ProposalType { get; set; }
        public int ItemId { get; set; }
        public int UserId { get; set; }
    }
}