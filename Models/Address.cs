using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovoUsoApi.Models
{
    public class Address
    {
        public required string ZipCode { get; set; }
        public required string State { get; set; }
        public required string City { get; set; }
        public required string Neighborhood { get; set; }
        public required string Address { get; set; }
        public string? Complement { get; set; }
    }
}