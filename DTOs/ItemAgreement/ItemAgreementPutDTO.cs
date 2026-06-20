using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using NovoUsoApi.Models.Enums;

namespace NovoUsoApi.DTOs.ItemAgreement
{
    public class ItemAgreementPutDTO
    {
        [Required(ErrorMessage = "O Identificador do lance é obrigatório.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo de status é obrigatório.")]
        public AgreementStatus Status { get; set; }
        public DateTime? OwnerAcceptedAtUtc { get; set; }
        public DateTime? WinnerAcceptedAtUtc { get; set; }
        public DateTime? ClosedAtUtc { get; set; }
        public string? RejectionReason { get; set; }
    }
}