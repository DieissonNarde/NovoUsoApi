using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovoUsoApi.DTOs.Category;

namespace NovoUsoApi.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<CategoryGetDTO> GetByIdAsync(int id);
        Task<List<CategoryGetDTO>> GetAllAsync();
    }
}