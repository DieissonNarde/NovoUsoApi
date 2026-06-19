using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovoUsoApi.DTOs.Item;

namespace NovoUsoApi.Services.Interfaces
{
    public interface IItemService
    {
        Task<ItemGetDTO> GetByIdAsync(int id);
        Task<List<ItemGetDTO>> GetAllAsync();
        Task<ItemGetDTO> AddAsync(ItemPostDTO itemPostDTO);
        Task<ItemGetDTO> UpdateAsync(ItemPutDTO itemPutDTO);
        Task<ItemGetDTO> DeleteAsync(int id);
    }
}