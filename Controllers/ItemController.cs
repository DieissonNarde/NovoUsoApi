using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NovoUsoApi.DTOs.Item;
using NovoUsoApi.Extensions;
using NovoUsoApi.Pagination;
using NovoUsoApi.Services.Interfaces;

namespace NovoUsoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }
        
        [HttpPost]
        public async Task<IActionResult> AddItem(ItemPostDTO itemPostDTO)
        {
            var createdItem = await _itemService.AddAsync(itemPostDTO);
            return Ok(new { message = "Item adicionado com sucesso."});
        }

        [HttpPut]
        public async Task<IActionResult> UpdateItem(ItemPutDTO itemPutDTO)
        {
            var updatedItem = await _itemService.UpdateAsync(itemPutDTO);
            return Ok(new { message = "Item atualizado com sucesso."});
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItem(int id)
        {
            var deletedItem = await _itemService.DeleteAsync(id);
            return Ok(new { message = "Item deletado com sucesso!"});
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetItemById(int id)
        {
            var item = await _itemService.GetByIdAsync(id);
            return Ok(item);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllItems(PaginationParams paginationParams)
        {
            var items = await _itemService.GetAllAsync(paginationParams.PageNumber, paginationParams.PageSize);

            Response.AddPaginationHeader(new PaginationHeader(paginationParams.PageNumber, paginationParams.PageSize, items.TotalCount, items.TotalPages));
            
            return Ok(items);
        }
    }
}