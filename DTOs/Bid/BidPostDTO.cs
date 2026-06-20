using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using NovoUsoApi.Models.Enums;

namespace NovoUsoApi.DTOs.Bid
{
    public class BidPostDTO
    {
        [Required(ErrorMessage = "O campo de data é obrigatório.")]
        [DataType(DataType.DateTime, ErrorMessage = "A data deve ser uma data válida.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "O campo de valor é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O valor precisa ter, no máximo, 50 caracteres.")]
        public string Value { get; set; } = null!;

        [Required(ErrorMessage = "O campo de descrição é obrigatório.")]
        [MaxLength(250, ErrorMessage = "A descrição precisa ter, no máximo, 250 caracteres.")]
        public string Description { get; set; } = null!;

        public BidStatus? Status { get; set; }

        [Required(ErrorMessage = "O campo de tipo de proposta é obrigatório.")]
        public ProposalType ProposalType { get; set; }

        [Required(ErrorMessage = "O campo de ID do item é obrigatório.")]
        public int ItemId { get; set; }

        [Required(ErrorMessage = "O campo de ID do usuário é obrigatório.")]
        public int UserId { get; set; }
    }
}