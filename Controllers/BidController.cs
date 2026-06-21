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
            return Ok(new { message = "Lance cadastrado com sucesso."});
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBid(BidPutDTO bidPutDTO)
        {
            var updatedBid = await _bidService.UpdateAsync(bidPutDTO);
            return Ok(new { message = "Lance atualizado com sucesso."});
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBid(int id)
        {
            var deletedBid = await _bidService.DeleteAsync(id);
            return Ok(new { message = "Lance deletado com sucesso!"});
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetBidById(int id)
        {
            var bid = await _bidService.GetByIdAsync(id);
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