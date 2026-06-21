using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovoUsoApi.DTOs.Category;
using NovoUsoApi.DTOs.Item;
using NovoUsoApi.DTOs.User;
using NovoUsoApi.Interfaces;
using NovoUsoApi.Middleawre.Errors;
using NovoUsoApi.Models;
using NovoUsoApi.Models.Enums;
using NovoUsoApi.Services.Interfaces;

namespace NovoUsoApi.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ItemService(IItemRepository itemRepository, IUserRepository userRepository, ICategoryRepository categoryRepository)
        {
            _itemRepository = itemRepository;
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<ItemGetDTO> AddAsync(ItemPostDTO itemPostDTO)
        {
            if (await _userRepository.GetByIdAsync(itemPostDTO.UserId) == null)
                throw new NotFoundException("Usuário não encrontado.");

            if (await _categoryRepository.GetByIdAsync(itemPostDTO.CategoryId) == null)
                throw new NotFoundException("Categoria não encrontada.");

            var item = new Item
            {
                Title = itemPostDTO.Title,
                Status = ItemStatus.Published,
                CreatedAtUtc = DateTime.UtcNow,
                Description = itemPostDTO.Description,
                Quantity = itemPostDTO.Quantity,
                ZipCode = itemPostDTO.ZipCode,
                State = itemPostDTO.State,
                City = itemPostDTO.City,
                Neighborhood = itemPostDTO.Neighborhood,
                Street = itemPostDTO.Street,
                Complement = itemPostDTO.Complement,
                DurationDays = itemPostDTO.DurationDays,
                TypeOffer = itemPostDTO.TypeOffer,
                Value = itemPostDTO.Value,
                UserId = itemPostDTO.UserId,
                CategoryId = itemPostDTO.CategoryId
            };

            var createdItem = await _itemRepository.AddAsync(item);
            return new ItemGetDTO
            {
                Id = createdItem.Id,
                Status = createdItem.Status,
                CreatedAtUtc = createdItem.CreatedAtUtc,
                Title = createdItem.Title,
                Description = createdItem.Description,
                Quantity = createdItem.Quantity,
                ZipCode = createdItem.ZipCode,
                State = createdItem.State,
                City = createdItem.City,
                Neighborhood = createdItem.Neighborhood,
                Street = createdItem.Street,
                Complement = createdItem.Complement,
                DurationDays = createdItem.DurationDays,
                TypeOffer = createdItem.TypeOffer,
                Value = createdItem.Value,
                UserId = createdItem.UserId,
                CategoryId = createdItem.CategoryId
            };
        }

        public async Task<ItemGetDTO> DeleteAsync(int id)
        {
            var deletedItem = await _itemRepository.DeleteAsync(id);
            if (deletedItem == null)
                throw new NotFoundException("Item não encontrado.");
            return new ItemGetDTO
            {
                Id = deletedItem.Id,
                Status = deletedItem.Status,
                CreatedAtUtc = deletedItem.CreatedAtUtc,
                Title = deletedItem.Title,
                Description = deletedItem.Description,
                Quantity = deletedItem.Quantity,
                ZipCode = deletedItem.ZipCode,
                State = deletedItem.State,
                City = deletedItem.City,
                Neighborhood = deletedItem.Neighborhood,
                Street = deletedItem.Street,
                Complement = deletedItem.Complement,
                DurationDays = deletedItem.DurationDays,
                TypeOffer = deletedItem.TypeOffer,
                Value = deletedItem.Value,
                UserId = deletedItem.UserId,
                CategoryId = deletedItem.CategoryId 
            };

        }

        public async Task<List<ItemGetDetailDTO>> GetAllAsync()
        {
            var items = await _itemRepository.GetAllAsync();
            var itemGetDTOs = new List<ItemGetDetailDTO>();
            foreach (var item in items)
            {
                itemGetDTOs.Add(new ItemGetDetailDTO
                {
                    Id = item.Id,
                    Status = item.Status,
                    CreatedAtUtc = item.CreatedAtUtc,
                    Title = item.Title,
                    Description = item.Description,
                    Quantity = item.Quantity,
                    ZipCode = item.ZipCode,
                    State = item.State,
                    City = item.City,
                    Neighborhood = item.Neighborhood,
                    Street = item.Street,
                    Complement = item.Complement,
                    DurationDays = item.DurationDays,
                    TypeOffer = item.TypeOffer,
                    Value = item.Value,
                    User = new UserGetDTO
                    {
                        Id = item.User.Id,
                        Name = item.User.Name
                    },
                    Category = new CategoryGetDTO
                    {
                        Id = item.Category.Id,
                        Name = item.Category.Name
                    }
                });
            }
            return itemGetDTOs;
        }

        public async Task<ItemGetDetailDTO> GetByIdAsync(int id)
        {
            var item = await _itemRepository.GetByIdAsync(id);
            if (item == null)
                throw new NotFoundException("Item não encontrado.");
            return new ItemGetDetailDTO
            {
                Id = item.Id,
                Status = item.Status,
                CreatedAtUtc = item.CreatedAtUtc,
                Title = item.Title,
                Description = item.Description,
                Quantity = item.Quantity,
                ZipCode = item.ZipCode,
                State = item.State,
                City = item.City,
                Neighborhood = item.Neighborhood,
                Street = item.Street,
                Complement = item.Complement,
                DurationDays = item.DurationDays,
                TypeOffer = item.TypeOffer,
                Value = item.Value,
                User = new UserGetDTO
                {
                    Id = item.User.Id,
                    Name = item.User.Name
                },
                Category = new CategoryGetDTO
                {
                    Id = item.Category.Id,
                    Name = item.Category.Name
                }
            };
        }

        public async Task<ItemGetDTO> UpdateAsync(ItemPutDTO itemPutDTO)
        {
            if (await _itemRepository.GetByIdAsync(itemPutDTO.Id) == null)
                throw new NotFoundException("Item não encontrado.");

            if (await _categoryRepository.GetByIdAsync(itemPutDTO.CategoryId) == null)
                throw new NotFoundException("Categoria não encrontada.");

            var item = new Item
            {
                Id = itemPutDTO.Id,
                Status = itemPutDTO.Status,
                Title = itemPutDTO.Title,
                Description = itemPutDTO.Description,
                Quantity = itemPutDTO.Quantity,
                ZipCode = itemPutDTO.ZipCode,
                State = itemPutDTO.State,
                City = itemPutDTO.City,
                Neighborhood = itemPutDTO.Neighborhood,
                Street = itemPutDTO.Street,
                Complement = itemPutDTO.Complement,
                DurationDays = itemPutDTO.DurationDays,
                TypeOffer = itemPutDTO.TypeOffer,
                Value = itemPutDTO.Value,
                CategoryId = itemPutDTO.CategoryId,
            };

            var updatedItem = await _itemRepository.UpdateAsync(item);
            if (updatedItem == null)
                return null;
            return new ItemGetDTO
            {   Id = updatedItem.Id,
                Status = updatedItem.Status,
                Title = updatedItem.Title,
                Description = updatedItem.Description,
                Quantity = updatedItem.Quantity,
                ZipCode = updatedItem.ZipCode,
                State = updatedItem.State,
                City = updatedItem.City,
                Neighborhood = updatedItem.Neighborhood,
                Street = updatedItem.Street,
                Complement = updatedItem.Complement,
                DurationDays = updatedItem.DurationDays,
                TypeOffer = updatedItem.TypeOffer,
                Value = updatedItem.Value,
                CategoryId = updatedItem.CategoryId
            };
        }
    }
}