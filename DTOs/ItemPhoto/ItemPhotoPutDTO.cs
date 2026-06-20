using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NovoUsoApi.DTOs.ItemPhoto
{
    public class ItemPhotoPutDTO
    {
        [Required(ErrorMessage = "O Identificador da foto do item é obrigatório.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo de nome do arquivo é obrigatório.")]
        public string FileName { get; set; }

        [Required(ErrorMessage = "O campo de tipo de conteúdo é obrigatório.")]
        public string ContentType { get; set; }

        [Required(ErrorMessage = "O campo de URL é obrigatório.")]
        public string Url { get; set; }

        [Required(ErrorMessage = "O campo de ID do item é obrigatório.")]
        public int ItemId { get; set; }
    }
}