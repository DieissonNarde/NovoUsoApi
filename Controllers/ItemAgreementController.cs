using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NovoUsoApi.DTOs.ItemAgreement;
using NovoUsoApi.Interfaces.Services;
using NovoUsoApi.Models;

namespace NovoUsoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemAgreementController : Controller
    {
        private readonly IItemAgreementService _itemAgreementService;
        public ItemAgreementController(IItemAgreementService itemAgreementService)
        {
            _itemAgreementService = itemAgreementService;
        }
        
        [HttpPost]
        public async Task<IActionResult> AddItemAgreement(ItemAgreementPostDTO itemAgreementPostDTO)
        {
            var createdItemAgreement = await _itemAgreementService.AddAsync(itemAgreementPostDTO);
            if (createdItemAgreement == null)
            {
                return BadRequest("Não foi possível adicionar o contrato de item.");
            }

            return Ok(new { message = "Contrato de item adicionado com sucesso."});
        }

        [HttpPut]
        public async Task<IActionResult> UpdateItemAgreement(ItemAgreementPutDTO itemAgreementPutDTO)
        {
            var updatedItemAgreement = await _itemAgreementService.UpdateAsync(itemAgreementPutDTO);
            if (updatedItemAgreement == null)
            {
                return BadRequest("Não foi possível atualizar o contrato de item.");
            }

            return Ok(new { message = "Contrato de item atualizado com sucesso."});
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetItemAgreementById(int id)
        {
            var itemAgreement = await _itemAgreementService.GetByIdAsync(id);
            if (itemAgreement == null)
            {
                return NotFound("Contrato de item não encontrado.");
            }

            return Ok(itemAgreement);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllItemAgreements()
        {
            var itemAgreements = await _itemAgreementService.GetAllAsync();
            return Ok(itemAgreements);
        }
    }
}