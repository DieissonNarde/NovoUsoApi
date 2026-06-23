using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NovoUsoApi.DTOs.ItemPhoto
{
    public class ItemPhotoPostDTO
    {
        [Required(ErrorMessage = "O campo de URL é obrigatório.")]
        public string Url { get; set; }

        [Required(ErrorMessage = "O campo de ID do item é obrigatório.")]
        public int ItemId { get; set; }

        public int Order { get; set; }
    }
}
