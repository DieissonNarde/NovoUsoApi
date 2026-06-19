using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NovoUsoApi.DTOs.User
{
    public class UserPutDTO
    {
        [Required(ErrorMessage = "O Identificador do usuário é obrigatório.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo de nome é obrigatório.")]
        [MaxLength(200, ErrorMessage = "O nome precisa ter, no máximo, 250 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo de email é obrigatório.")]
        [MaxLength(200, ErrorMessage = "O email precisa ter, no máximo, 250 caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo de whatsapp é obrigatório.")]
        [MaxLength(20, ErrorMessage = "O whatsapp precisa ter, no máximo, 20 caracteres.")]
        public string Whatsapp { get; set; }

        [Required(ErrorMessage = "O campo de CPF/CNPJ é obrigatório.")]
        [MaxLength(20, ErrorMessage = "O CPF/CNPJ precisa ter, no máximo, 20 caracteres.")]
        public string CpfCnpj { get; set; }

        [Required(ErrorMessage = "O campo de data de nascimento é obrigatório.")]
        [DataType(DataType.Date, ErrorMessage = "A data de nascimento deve ser uma data válida.")]
        public DateOnly DateBirth { get; set; }
    }
}