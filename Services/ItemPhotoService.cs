using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovoUsoApi.DTOs.ItemPhoto;
using NovoUsoApi.Interfaces;
using NovoUsoApi.Interfaces.Services;
using NovoUsoApi.Models;

namespace NovoUsoApi.Services
{
    public class ItemPhotoService : IItemPhotoService
    {
        private readonly IItemPhotoRepository _itemPhotoRepository;
        public ItemPhotoService(IItemPhotoRepository itemPhotoRepository)
        {
            _itemPhotoRepository = itemPhotoRepository;
        }

        public async Task<ItemPhotoGetDTO> AddAsync(ItemPhotoPostDTO itemPhotoPostDTO)
        {
            var itemPhoto = new ItemPhoto
            {
                FileName = itemPhotoPostDTO.FileName,
                ContentType = itemPhotoPostDTO.ContentType,
                Url = itemPhotoPostDTO.Url,
                ItemId = itemPhotoPostDTO.ItemId
            };

            var createdItemPhoto = await _itemPhotoRepository.AddAsync(itemPhoto);
            return new ItemPhotoGetDTO
            {
                Id = createdItemPhoto.Id,
                FileName = createdItemPhoto.FileName,
                ContentType = createdItemPhoto.ContentType,
                Url = createdItemPhoto.Url,
                ItemId = createdItemPhoto.ItemId
            };
        }

        public async Task<ItemPhotoGetDTO> DeleteAsync(int id)
        {
            var deletedItemPhoto = await _itemPhotoRepository.DeleteAsync(id);
            return new ItemPhotoGetDTO
            {
                Id = deletedItemPhoto.Id,
                FileName = deletedItemPhoto.FileName,
                ContentType = deletedItemPhoto.ContentType,
                Url = deletedItemPhoto.Url,
                ItemId = deletedItemPhoto.ItemId
            };
        }

        public async Task<List<ItemPhotoGetDTO>> GetAllAsync()
        {
            var itemPhotos = await _itemPhotoRepository.GetAllAsync();
            return itemPhotos.Select(itemPhoto => new ItemPhotoGetDTO
            {
                Id = itemPhoto.Id,
                FileName = itemPhoto.FileName,
                ContentType = itemPhoto.ContentType,
                Url = itemPhoto.Url,
                ItemId = itemPhoto.ItemId
            }).ToList();
        }

        public async Task<ItemPhotoGetDTO> GetByIdAsync(int id)
        {
            var itemPhoto = await _itemPhotoRepository.GetByIdAsync(id);
            return new ItemPhotoGetDTO
            {
                Id = itemPhoto.Id,
                FileName = itemPhoto.FileName,
                ContentType = itemPhoto.ContentType,
                Url = itemPhoto.Url,
                ItemId = itemPhoto.ItemId
            };
        }

        public async Task<ItemPhotoGetDTO> UpdateAsync(ItemPhotoPutDTO itemPhotoPutDTO)
        {
            var itemPhoto = new ItemPhoto
            {
                Id = itemPhotoPutDTO.Id,
                FileName = itemPhotoPutDTO.FileName,
                ContentType = itemPhotoPutDTO.ContentType,
                Url = itemPhotoPutDTO.Url
            };

            var updatedItemPhoto = await _itemPhotoRepository.UpdateAsync(itemPhoto);
            if (updatedItemPhoto == null)
            {
                return null;
            }
            return new ItemPhotoGetDTO
            {
                Id = updatedItemPhoto.Id,
                FileName = updatedItemPhoto.FileName,
                ContentType = updatedItemPhoto.ContentType,
                Url = updatedItemPhoto.Url
            };
        }
    }
}