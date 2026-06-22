using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NovoUsoApi.DTOs.User
{
    public class UserLoginDTO
    {
        [Required(ErrorMessage = "O campo de email é obrigatório.")]
        [MaxLength(200, ErrorMessage = "O email precisa ter, no máximo, 250 caracteres.")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "O campo de senha é obrigatório.")]
        [MinLength(6, ErrorMessage = "A senha precisa ter, no mínimo, 6 caracteres.")]
        [MaxLength(100, ErrorMessage = "A senha precisa ter, no máximo, 100 caracteres.")]
        public string Password { get; set; }
    }
}