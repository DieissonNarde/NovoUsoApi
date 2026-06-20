using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovoUsoApi.DTOs.User;

namespace NovoUsoApi.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserGetDTO> GetByIdAsync(int id);
        Task<List<UserGetDTO>> GetAllAsync();
        Task<UserGetDTO> AddAsync(UserPostDTO userPostDTO);
        Task<UserGetDTO> UpdateAsync(UserPutDTO userPutDTO);
        Task<UserGetDTO> DeleteAsync(int id);
    }
}