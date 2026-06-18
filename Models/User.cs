using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovoUsoApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Whatsapp { get; set; }
        public string CpfCnpj { get; set; }
        public DateOnly DateBirth { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public ICollection<Item> Items { get; set; } = new List<Item>();
        public ICollection<Bid> Bids { get; set; } = new List<Bid>();
    }
}