using Application.Services;
using Data.Context;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Models.Request;
using System;
using Xunit;

namespace Test.Application.Services
{
    public class UserServiceTest
    {
        [Fact]
        public async void CreateUser_Succes()
        {
            var options = new DbContextOptionsBuilder<BlogDbContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
                  .Options;

            var dbContext = new BlogDbContext(options);
            dbContext.Database.EnsureCreated();

            UserService userService = new UserService(dbContext);

            var result = userService.CreateUser(new User() { Id = 1, Role = "", Password = "", UserName = "" }).Result;
            Assert.True(result);
        }

        [Fact]
        public async void CreateUser_Catch()
        {
            var options = new DbContextOptionsBuilder<BlogDbContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
                  .Options;

            var dbContext = new BlogDbContext(options);
            dbContext.Database.EnsureCreated();

            UserService userService = new UserService(dbContext);

            var result = userService.CreateUser(new User() { Id = 1, Role = "", Password = "" }).Result;
            Assert.False(result);
        }

        [Fact]
        public async void Login_Succes()
        {
            var options = new DbContextOptionsBuilder<BlogDbContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
                  .Options;

            var dbContext = new BlogDbContext(options);
            dbContext.Database.EnsureCreated();

            UserService userService = new UserService(dbContext);

            if (await dbContext.Posts.CountAsync() <= 0)
            {
                dbContext.Users.Add(new User() { UserName = "sostito", Id = 1, Password = "holamundo" });
                await dbContext.SaveChangesAsync();
            }

            var result = userService.Login(new Login() { UserName = "sostito", Password = "holamundo" }).Result;
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async void Login_Fail()
        {
            var options = new DbContextOptionsBuilder<BlogDbContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
                  .Options;

            var dbContext = new BlogDbContext(options);
            dbContext.Database.EnsureCreated();

            UserService userService = new UserService(dbContext);

            if (await dbContext.Posts.CountAsync() <= 0)
            {
                dbContext.Users.Add(new User() { UserName = "sostito", Id = 1, Password = "holamundo" });
                await dbContext.SaveChangesAsync();
            }

            var result = userService.Login(new Login() { UserName = "persona", Password = "holamundo" }).Result;
            Assert.Null(result);
        }
    }
}
