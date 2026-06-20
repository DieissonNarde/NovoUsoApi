using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovoUsoApi.DTOs.ItemPhoto
{
    public class ItemPhotoGetDTO
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public string Url { get; set; }
        public int ItemId { get; set; }
    }
}