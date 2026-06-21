using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovoUsoApi.DTOs.Category;
using NovoUsoApi.DTOs.User;
using NovoUsoApi.Models.Enums;

namespace NovoUsoApi.DTOs.Item
{
    public class ItemGetDetailDTO
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
        public UserGetDTO User { get; set; }
        public CategoryGetDTO Category { get; set; }
    }
}