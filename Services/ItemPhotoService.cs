using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovoUsoApi.DTOs.ItemPhoto;
using NovoUsoApi.Interfaces;
using NovoUsoApi.Interfaces.Services;
using NovoUsoApi.Middleawre.Errors;
using NovoUsoApi.Models;

namespace NovoUsoApi.Services
{
    public class ItemPhotoService : IItemPhotoService
    {
        private readonly IItemPhotoRepository _itemPhotoRepository;
        private readonly IItemRepository _itemRepository;

        public ItemPhotoService(IItemPhotoRepository itemPhotoRepository, IItemRepository itemRepository)
        {
            _itemPhotoRepository = itemPhotoRepository;
            _itemRepository = itemRepository;
        }

        public async Task<ItemPhotoGetDTO> AddAsync(ItemPhotoPostDTO itemPhotoPostDTO)
        {
            if (await _itemRepository.GetByIdAsync(itemPhotoPostDTO.ItemId) == null)
                throw new NotFoundException("Item não encontrado.");

            var itemPhoto = new ItemPhoto
            {
                Url = itemPhotoPostDTO.Url,
                ItemId = itemPhotoPostDTO.ItemId
            };

            var createdItemPhotos = await _itemPhotoRepository.AddAsync(new List<ItemPhoto> { itemPhoto });
            var createdItemPhoto = createdItemPhotos.First();
            return new ItemPhotoGetDTO
            {
                Id = createdItemPhoto.Id,
                Url = createdItemPhoto.Url,
                Order = createdItemPhoto.Order,
                ItemId = createdItemPhoto.ItemId
            };
        }

        public async Task<ItemPhotoGetDTO> DeleteAsync(int id)
        {
            var deletedItemPhoto = await _itemPhotoRepository.DeleteAsync(id);
            if (deletedItemPhoto == null)
                throw new NotFoundException("Foto do Item não encontrado.");

            return new ItemPhotoGetDTO
            {
                Id = deletedItemPhoto.Id,
                Url = deletedItemPhoto.Url,
                Order = deletedItemPhoto.Order,
                ItemId = deletedItemPhoto.ItemId
            };
        }

        public async Task<List<ItemPhotoGetDTO>> GetAllAsync()
        {
            var itemPhotos = await _itemPhotoRepository.GetAllAsync();
            return itemPhotos.Select(itemPhoto => new ItemPhotoGetDTO
            {
                Id = itemPhoto.Id,
                Url = itemPhoto.Url,
                Order = itemPhoto.Order,
                ItemId = itemPhoto.ItemId
            }).ToList();
        }

        public async Task<ItemPhotoGetDTO> GetByIdAsync(int id)
        {
            var itemPhoto = await _itemPhotoRepository.GetByIdAsync(id);
            if (itemPhoto == null)
                throw new NotFoundException("Foto do Item não encontrado.");

            return new ItemPhotoGetDTO
            {
                Id = itemPhoto.Id,
                Url = itemPhoto.Url,
                Order = itemPhoto.Order,
                ItemId = itemPhoto.ItemId
            };
        }

        public async Task<ItemPhotoGetDTO> UpdateAsync(ItemPhotoPutDTO itemPhotoPutDTO)
        {
            var existingPhoto = await _itemPhotoRepository.GetByIdAsync(itemPhotoPutDTO.Id);
            if (existingPhoto == null)
                throw new NotFoundException("Foto do Item não encontrado.");

            var itemPhoto = new ItemPhoto
            {
                Id = itemPhotoPutDTO.Id,
                Url = itemPhotoPutDTO.Url,
                Order = itemPhotoPutDTO.Order,
                ItemId = itemPhotoPutDTO.ItemId
            };

            var updatedItemPhoto = await _itemPhotoRepository.UpdateAsync(itemPhoto);
            if (updatedItemPhoto == null)
            {
                return null;
            }
            return new ItemPhotoGetDTO
            {
                Id = updatedItemPhoto.Id,
                Url = updatedItemPhoto.Url,
                Order = updatedItemPhoto.Order,
                ItemId = updatedItemPhoto.ItemId
            };
        }
    }
}
