using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovoUsoApi.DTOs.Category;
using NovoUsoApi.DTOs.Item;
using NovoUsoApi.DTOs.ItemPhoto;
using NovoUsoApi.DTOs.User;
using NovoUsoApi.Interfaces;
using NovoUsoApi.Middleawre.Errors;
using NovoUsoApi.Models;
using NovoUsoApi.Models.Enums;
using NovoUsoApi.Pagination;
using NovoUsoApi.Services.Interfaces;

namespace NovoUsoApi.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IItemPhotoRepository _itemPhotoRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IWebHostEnvironment _env;

        public ItemService(IItemRepository itemRepository, IItemPhotoRepository itemPhotoRepository, IUserRepository userRepository, ICategoryRepository categoryRepository, IWebHostEnvironment env)
        {
            _itemRepository = itemRepository;
            _itemPhotoRepository = itemPhotoRepository;
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
            _env = env;
        }

        public async Task<ItemGetDTO> AddAsync(ItemPostDTO itemPostDTO)
        {
            if (await _userRepository.GetByIdAsync(itemPostDTO.UserId) == null)
                throw new NotFoundException("Usuário não encrontado.");

            if (await _categoryRepository.GetByIdAsync(itemPostDTO.CategoryId) == null)
                throw new NotFoundException("Categoria não encrontada.");

            // 1. Validação da quantidade de imagens
            if (itemPostDTO.Images != null && itemPostDTO.Images.Count > 6)
            {
                throw new ArgumentException("Máximo de 6 imagens permitidas.");
            }

            // 2. Validações de tipo/tamanho (exemplo)
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            const long maxFileSize = 5 * 1024 * 1024; // 5 MB

            if (itemPostDTO.Images != null)
            {
                foreach (var file in itemPostDTO.Images)
                {
                    var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
                    if (!allowedExtensions.Contains(ext))
                        throw new ArgumentException($"Formato não permitido: {ext}");

                    if (file.Length > maxFileSize)
                        throw new ArgumentException($"Arquivo {file.FileName} excede 5MB.");
                }
            }

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

            // 4. Salvar as imagens e registrar no banco
            if (itemPostDTO.Images != null && itemPostDTO.Images.Any())
            {
                // Define a pasta onde as imagens serão armazenadas (ex: wwwroot/uploads/items)
                var webRootPath = _env.WebRootPath;
                if (string.IsNullOrWhiteSpace(webRootPath))
                    webRootPath = Path.Combine(_env.ContentRootPath, "uploads");

                var uploadsFolder = Path.Combine(webRootPath, "items");
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                var imageList = new List<ItemPhoto>();
                int order = 0;

                foreach (var file in itemPostDTO.Images)
                {
                    // Gera um nome único para evitar conflitos
                    var uniqueName = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";
                    var filePath = Path.Combine(uploadsFolder, uniqueName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    // Caminho relativo para salvar no banco (ex: /uploads/items/guid_nome.jpg)
                    var relativePath = $"/items/{uniqueName}";

                    imageList.Add(new ItemPhoto
                    {
                        Url = relativePath,
                        Order = order++,
                        ItemId = item.Id
                    });
                }

                await _itemPhotoRepository.AddAsync(imageList);
            }

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

        public async Task<PagedList<ItemGetDetailDTO>> GetAllAsync(int pageNumber, int pageSize)
        {
            var items = await _itemRepository.GetAllAsync(pageNumber, pageSize);
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
            return new PagedList<ItemGetDetailDTO>(itemGetDTOs, items.CurrentPage, items.PageSize, items.TotalCount);
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
            {
                Id = updatedItem.Id,
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
