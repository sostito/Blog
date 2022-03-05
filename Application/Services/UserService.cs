using Application.Services.Interface;
using Data.Context;
using Data.Models;
using Models.Request;
using Microsoft.EntityFrameworkCore;
using Models.Dto;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly BlogDbContext blogDbContext;

        public UserService(BlogDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
        }

        public async Task<bool> CreateUser(User user)
        {
            try
            {
                blogDbContext.Add(user);
                var result = await blogDbContext.SaveChangesAsync();
                return result > 0;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<UserDto> Login(Login login)
        {
            var isValid = await blogDbContext.Users.AnyAsync(x => (x.UserName == login.UserName) && (x.Password == login.Password));

            if (!isValid)
                return null;

            var user = await blogDbContext.Users.FirstAsync(x => (x.UserName == login.UserName) && (x.Password == login.Password));
            return new UserDto { Id = user.Id, Role = user.Role };
        }
    }
}
