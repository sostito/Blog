using Models.Dto;

namespace Application.Services.Interface
{
    public interface ITokenService
    {
        string GetToken(UserDto user);
    }
}
