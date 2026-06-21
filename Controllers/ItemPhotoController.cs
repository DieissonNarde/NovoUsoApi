using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NovoUsoApi.DTOs.ItemPhoto;
using NovoUsoApi.Interfaces.Services;

namespace NovoUsoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemPhotoController : Controller
    {
        private readonly IItemPhotoService _itemPhotoService;
        public ItemPhotoController(IItemPhotoService itemPhotoService)
        {
            _itemPhotoService = itemPhotoService;
        }

        [HttpPost]
        public async Task<IActionResult> AddItemPhoto(int itemId, ItemPhotoPostDTO itemPhotoPostDTO)
        {
            var addPhoto = await _itemPhotoService.AddAsync(itemPhotoPostDTO);
            if (addPhoto == null)
            {
                return BadRequest("Não foi possível adicionar a foto ao item.");
            }

            return Ok(new { message = "Foto adicionada ao item com sucesso.", addPhoto });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateItemPhoto(ItemPhotoPutDTO itemPhotoPutDTO)
        {
            var updatedItemPhoto = await _itemPhotoService.UpdateAsync(itemPhotoPutDTO);
            if (updatedItemPhoto == null)
            {
                return BadRequest("Não foi possível atualizar a foto do item.");
            }

            return Ok(new { message = "A foto do item foi atualizado com sucesso."});
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItemPhoto(int id)
        {
            var deletedItemPhoto = await _itemPhotoService.DeleteAsync(id);
            if (deletedItemPhoto == null)
            {
                return BadRequest("Ocorreu um erro ao deletar a foto do item.");
            }

            return Ok(new { message = "A foto do item foi deletado com sucesso!"});
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetItemPhotoById(int id)
        {
            var itemPhoto = await _itemPhotoService.GetByIdAsync(id);
            if (itemPhoto == null)
            {
                return NotFound("A foto do item não foi encontrado.");
            }

            return Ok(itemPhoto);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllItemPhotos()
        {
            var itemPhotos = await _itemPhotoService.GetAllAsync();
            return Ok(itemPhotos);
        }
    
    }
}