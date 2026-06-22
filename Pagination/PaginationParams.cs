using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NovoUsoApi.Pagination
{
    public class PaginationParams
    {
        [Range(1, int.MaxValue, ErrorMessage = "A página deve ser maior que 1.")]
        public int PageNumber { get; set; }
        [Range(1, 50, ErrorMessage = "O tamanho da página deve ser maior que 1 e, no máximo, 50 itens.")]
        public int PageSize { get; set; }
    }
}