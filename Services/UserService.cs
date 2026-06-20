using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovoUsoApi.DTOs.User;
using NovoUsoApi.Interfaces;
using NovoUsoApi.Interfaces.Services;
using NovoUsoApi.Models;

namespace NovoUsoApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserGetDTO> AddAsync(UserPostDTO userPostDTO)
        {
            var user = new User
            {
                Name = userPostDTO.Name,
                Email = userPostDTO.Email,
                Whatsapp = userPostDTO.Whatsapp,
                CpfCnpj = userPostDTO.CpfCnpj,
                DateBirth = userPostDTO.DateBirth
            };

            var createdUser = await _userRepository.AddAsync(user);
            return new UserGetDTO
            {
                Id = createdUser.Id,
                Name = createdUser.Name,
                Email = createdUser.Email,
                Whatsapp = createdUser.Whatsapp,
                CpfCnpj = createdUser.CpfCnpj,
                DateBirth = createdUser.DateBirth
            };
        }

        public async Task<UserGetDTO> DeleteAsync(int id)
        {
            var deletedUser = await _userRepository.DeleteAsync(id);
            return new UserGetDTO
            {
                Id = deletedUser.Id,
                Name = deletedUser.Name,
                Email = deletedUser.Email,
                Whatsapp = deletedUser.Whatsapp,
                CpfCnpj = deletedUser.CpfCnpj,
                DateBirth = deletedUser.DateBirth
            };
        }

        public async Task<List<UserGetDTO>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(user => new UserGetDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Whatsapp = user.Whatsapp,
                CpfCnpj = user.CpfCnpj,
                DateBirth = user.DateBirth
            }).ToList();
        }

        public async Task<UserGetDTO> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return null;
            return new UserGetDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Whatsapp = user.Whatsapp,
                CpfCnpj = user.CpfCnpj,
                DateBirth = user.DateBirth
            };
        }

        public async Task<UserGetDTO> UpdateAsync(UserPutDTO userPutDTO)
        {
            var user = new User
            {
                Id = userPutDTO.Id,
                Name = userPutDTO.Name,
                Email = userPutDTO.Email,
                Whatsapp = userPutDTO.Whatsapp,
                CpfCnpj = userPutDTO.CpfCnpj,
                DateBirth = userPutDTO.DateBirth
            };

            var updatedUser = await _userRepository.UpdateAsync(user);
            if (updatedUser == null)
                return null;
            return new UserGetDTO
            {
                Id = updatedUser.Id,
                Name = updatedUser.Name,
                Email = updatedUser.Email,
                Whatsapp = updatedUser.Whatsapp,
                CpfCnpj = updatedUser.CpfCnpj,
                DateBirth = updatedUser.DateBirth
            };
        }
    }
}