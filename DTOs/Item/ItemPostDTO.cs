using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using NovoUsoApi.Models.Enums;

namespace NovoUsoApi.DTOs.Item
{
    public class ItemPostDTO
    {
        [Required(ErrorMessage = "O campo de título é obrigatório.")]
        [MaxLength(200, ErrorMessage = "O título precisa ter, no máximo, 200 caracteres.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "O campo de descrição é obrigatório.")]
        [MaxLength(400, ErrorMessage = "A descrição precisa ter, no máximo, 400 caracteres.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "O campo de quantidade é obrigatório.")]
        [MaxLength(50, ErrorMessage = "A quantidade precisa ter, no máximo, 50 caracteres.")]
        public string Quantity { get; set; }

        [Required(ErrorMessage = "O campo de CEP é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O CEP precisa ter, no máximo, 50 caracteres.")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "O campo de estado é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O estado precisa ter, no máximo, 50 caracteres.")]
        public string State { get; set; }

        [Required(ErrorMessage = "O campo de cidade é obrigatório.")]
        [MaxLength(50, ErrorMessage = "A cidade precisa ter, no máximo, 50 caracteres.")]
        public string City { get; set; }

        [Required(ErrorMessage = "O campo de bairro é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O bairro precisa ter, no máximo, 50 caracteres.")]
        public string Neighborhood { get; set; }

        [Required(ErrorMessage = "O campo de rua é obrigatório.")]
        [MaxLength(50, ErrorMessage = "A rua precisa ter, no máximo, 50 caracteres.")]
        public string Street { get; set; }

        [MaxLength(50, ErrorMessage = "O complemento precisa ter, no máximo, 50 caracteres.")]  
        public string? Complement { get; set; }

        [Required(ErrorMessage = "O campo de duração é obrigatório.")]
        public ListingDuration DurationDays { get; set; }

        [Required(ErrorMessage = "O campo de tipo de oferta é obrigatório.")]
        public TypeOffer TypeOffer { get; set; }

        [MaxLength(20, ErrorMessage = "O valor precisa ter, no máximo, 20 caracteres.")]
        public string? Value { get; set; }

        [Required(ErrorMessage = "O identificador de usuário é obrigatório.")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "O identificador de categoria é obrigatório.")]
        public int CategoryId { get; set; }

        public List<IFormFile>? Images { get; set; }
    }
}