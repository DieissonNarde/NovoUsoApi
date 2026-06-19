using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovoUsoApi.DTOs.User
{
    public class UserPostDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Whatsapp { get; set; }
        public string CpfCnpj { get; set; }
        public DateOnly DateBirth { get; set; }
    }
}