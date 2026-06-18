using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovoUsoApi.Models
{
    public class ItemPhoto
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public string Url { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; } = null!;
    }
}