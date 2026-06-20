using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovoUsoApi.DTOs.ItemPhoto;

namespace NovoUsoApi.Interfaces.Services
{
    public interface IItemPhotoService
    {
        Task<ItemPhotoGetDTO> GetByIdAsync(int id);
        Task<List<ItemPhotoGetDTO>> GetAllAsync();
        Task<ItemPhotoGetDTO> AddAsync(ItemPhotoPostDTO itemPhotoPostDTO);
        Task<ItemPhotoGetDTO> UpdateAsync(ItemPhotoPutDTO itemPhotoPutDTO);
        Task<ItemPhotoGetDTO> DeleteAsync(int id);
    }
}