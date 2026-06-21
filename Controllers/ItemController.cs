using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NovoUsoApi.DTOs.Item;
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
            if (createdItem == null)
            {
                return BadRequest("Não foi possível adicionar o item.");
            }

            return Ok(new { message = "Item adicionado com sucesso."});
        }

        [HttpPut]
        public async Task<IActionResult> UpdateItem(ItemPutDTO itemPutDTO)
        {
            var updatedItem = await _itemService.UpdateAsync(itemPutDTO);
            if (updatedItem == null)
            {
                return BadRequest("Não foi possível atualizar o item.");
            }

            return Ok(new { message = "Item atualizado com sucesso."});
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItem(int id)
        {
            var deletedItem = await _itemService.DeleteAsync(id);
            if (deletedItem == null)
            {
                return BadRequest("Ocorreu um erro ao deletar o item.");
            }

            return Ok(new { message = "Item deletado com sucesso!"});
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetItemById(int id)
        {
            var item = await _itemService.GetByIdAsync(id);
            if (item == null)
            {
                return NotFound("Item não encontrado.");
            }

            return Ok(item);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllItems()
        {
            var items = await _itemService.GetAllAsync();
            return Ok(items);
        }
    }
}