using Data.Models;
using Models.Dto;
using Models.Request;

namespace Application.Services.Interface
{
    public interface IUserService
    {
        Task<bool> CreateUser(User user);
        Task<UserDto> Login(Login login);
    }
}
