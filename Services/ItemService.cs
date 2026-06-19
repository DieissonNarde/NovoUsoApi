using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovoUsoApi.DTOs.Item;
using NovoUsoApi.Interfaces;
using NovoUsoApi.Models;
using NovoUsoApi.Services.Interfaces;

namespace NovoUsoApi.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<ItemGetDTO> AddAsync(ItemPostDTO itemPostDTO)
        {
            var item = new Item
            {
                Title = itemPostDTO.Title,
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
                return null;
            return new ItemGetDTO
            {
                Id = deletedItem.Id,
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

        public async Task<List<ItemGetDTO>> GetAllAsync()
        {
            var items = await _itemRepository.GetAllAsync();
            var itemGetDTOs = new List<ItemGetDTO>();
            foreach (var item in items)            {
                itemGetDTOs.Add(new ItemGetDTO
                {
                    Id = item.Id,
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
                    UserId = item.UserId,
                    CategoryId = item.CategoryId
                });
            }
            return itemGetDTOs;
        }

        public async Task<ItemGetDTO> GetByIdAsync(int id)
        {
            var item = await _itemRepository.GetByIdAsync(id);
            if (item == null)
                return null;
            return new ItemGetDTO
            {
                Id = item.Id,
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
                UserId = item.UserId,
                CategoryId = item.CategoryId
            };
        }

        public async Task<ItemGetDTO> UpdateAsync(ItemPutDTO itemPutDTO)
        {
            var item = new Item
            {
                Id = itemPutDTO.Id,
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
                UserId = itemPutDTO.UserId,
                CategoryId = itemPutDTO.CategoryId
            };

            var updatedItem = await _itemRepository.UpdateAsync(item);
            if (updatedItem == null)
                return null;
            return new ItemGetDTO
            {   Id = updatedItem.Id,
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
                UserId = updatedItem.UserId,
                CategoryId = updatedItem.CategoryId
            };
        }
    }
}