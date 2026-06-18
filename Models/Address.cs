using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovoUsoApi.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public string Street { get; set; }
        public string? Complement { get; set; }

        public ICollection<Item> Items { get; set; } = new List<Item>();
    }
}