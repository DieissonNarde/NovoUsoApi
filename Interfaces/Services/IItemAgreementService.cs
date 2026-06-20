using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovoUsoApi.DTOs.ItemAgreement;
using NovoUsoApi.Models;

namespace NovoUsoApi.Interfaces.Services
{
    public interface IItemAgreementService
    {
        Task<ItemAgreementGetDetailDTO> GetByIdAsync(int id);
        Task<List<ItemAgreementGetDTO>> GetAllAsync();
        Task<ItemAgreementGetDTO> AddAsync(ItemAgreementPostDTO itemAgreementPostDTO);
        Task<ItemAgreementGetDTO> UpdateAsync(ItemAgreementPutDTO itemAgreementPutDTO);
    }
}