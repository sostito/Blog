using Application.Services;
using Models.Dto;
using Xunit;

namespace Test.Application.Services
{
    public class TokenServiceTest
    {
        [Fact]
        public void GetToken_Succes()
        {
            TokenService tokenService = new TokenService();

            string token = tokenService.GetToken(new UserDto() { Role = "Developer" });

            Assert.True(!string.IsNullOrEmpty(token));
        }

        [Fact]
        public void GetToken_Catch()
        {
            TokenService tokenService = new TokenService();

            string token = tokenService.GetToken(new UserDto());

            Assert.True(string.IsNullOrEmpty(token));
        }
    }
}
