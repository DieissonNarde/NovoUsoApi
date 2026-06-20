using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovoUsoApi.DTOs.Category;
using NovoUsoApi.Interfaces;
using NovoUsoApi.Interfaces.Services;

namespace NovoUsoApi.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryGetDTO>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return categories.Select(category => new CategoryGetDTO
            {
                Id = category.Id,
                Name = category.Name
            }).ToList();
        }

        public async Task<CategoryGetDTO> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return null;
            }

            return new CategoryGetDTO
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}