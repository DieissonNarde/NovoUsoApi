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
        public ItemStatus Status { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Quantity { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public string Street { get; set; }
        public string? Complement { get; set; }
        public ListingDuration DurationDays { get; set; }
        public TypeOffer TypeOffer { get; set; }
        public string? Value { get; set; }
        public string? CancellationReason { get; set; }

        public ICollection<ItemPhoto> Photos { get; set; } = new List<ItemPhoto>();
        public ICollection<Bid> Bids { get; set; } = new List<Bid>();

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}