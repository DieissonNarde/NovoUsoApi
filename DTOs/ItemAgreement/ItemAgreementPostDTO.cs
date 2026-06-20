using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using NovoUsoApi.Models.Enums;

namespace NovoUsoApi.DTOs.ItemAgreement
{
    public class ItemAgreementPostDTO
    {
        public DateTime? OwnerAcceptedAtUtc { get; set; }
        public DateTime? WinnerAcceptedAtUtc { get; set; }
        public DateTime? ClosedAtUtc { get; set; }
        public string? RejectionReason { get; set; }

        [Required(ErrorMessage = "O identificador do item é obrigatório.")]
        public int ItemId { get; set; }

        [Required(ErrorMessage = "O identificador do lance é obrigatório.")]
        public int BidId { get; set; }
    }
}