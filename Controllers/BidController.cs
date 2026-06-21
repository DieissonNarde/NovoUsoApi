using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NovoUsoApi.DTOs.Bid;
using NovoUsoApi.Interfaces.Services;

namespace NovoUsoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BidController : Controller
    {
        private readonly IBidService _bidService;
        public BidController(IBidService bidService)
        {
            _bidService = bidService;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateBid(BidPostDTO bidPostDTO)
        {
            var createdBid = await _bidService.AddAsync(bidPostDTO);
            if (createdBid == null)
            {
                return BadRequest("Não foi possível criar o lance.");
            }

            return Ok(new { message = "Lance cadastrado com sucesso."});
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBid(BidPutDTO bidPutDTO)
        {
            var updatedBid = await _bidService.UpdateAsync(bidPutDTO);
            if (updatedBid == null)
            {
                return BadRequest("Não foi possível atualizar o lance.");
            }

            return Ok(new { message = "Lance atualizado com sucesso."});
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBid(int id)
        {
            var deletedBid = await _bidService.DeleteAsync(id);
            if (deletedBid == null)
            {
                return BadRequest("Ocorreu um erro ao deletar o lance.");
            }

            return Ok(new { message = "Lance deletado com sucesso!"});
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetBidById(int id)
        {
            var bid = await _bidService.GetByIdAsync(id);
            if (bid == null)
            {
                return NotFound("Lance não encontrado.");
            }

            return Ok(bid);
        }

        [HttpGet]
        public async Task<ActionResult> GetBidItems()
        {
            var bids = await _bidService.GetAllAsync();
            return Ok(bids);
        }
    }
}