using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovoUsoApi.DTOs.Item;
using NovoUsoApi.Pagination;

namespace NovoUsoApi.Services.Interfaces
{
    public interface IItemService
    {
        Task<ItemGetDetailDTO> GetByIdAsync(int id);
        Task<PagedList<ItemGetDetailDTO>> GetAllAsync(int pageNumber, int pageSize);
        Task<ItemGetDTO> AddAsync(ItemPostDTO itemPostDTO);
        Task<ItemGetDTO> UpdateAsync(ItemPutDTO itemPutDTO);
        Task<ItemGetDTO> DeleteAsync(int id);
    }
}