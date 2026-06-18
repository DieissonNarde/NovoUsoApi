using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovoUsoApi.Models.Enums;

namespace NovoUsoApi.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Quantity { get; set; }
        public string Duration { get; set; }
        public string Value { get; set; }
        public TypeOffer TypeOffer { get; set; }
        public ItemStatus Status { get; set; } = ItemStatus.Published;
        public string? CancellationReason { get; set; }

        public ICollection<ItemPhoto> Photos { get; set; } = new List<ItemPhoto>();
        public ICollection<Bid> Bids { get; set; } = new List<Bid>();
        public ItemAgreement? Agreement { get; set; }

        public int OwnerId { get; set; }
        public User Owner { get; set; } = null!;

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}