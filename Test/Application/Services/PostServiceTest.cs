using Application.Services;
using Data.Context;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace Test.Application.Services
{
    public class PostServiceTest
    {
        [Fact]
        public async void WritePost_Succes()
        {
            var options = new DbContextOptionsBuilder<BlogDbContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
                  .Options;

            var dbContext = new BlogDbContext(options);
            dbContext.Database.EnsureCreated();

            if (await dbContext.Posts.CountAsync() <= 0)
            {
                dbContext.Posts.Add(new Post() { Content = "", Id = 1 });
                await dbContext.SaveChangesAsync();
            }

            PostService postService = new PostService(dbContext);

            var result = postService.WritePost(new Post() { Content = "Hola mundo" }, "1").Result;
            Assert.True(result);
        }

        [Fact]
        public async void WritePost_Catch()
        {
            var options = new DbContextOptionsBuilder<BlogDbContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
                  .Options;

            var dbContext = new BlogDbContext(options);
            dbContext.Database.EnsureCreated();

            if (await dbContext.Posts.CountAsync() <= 0)
            {
                dbContext.Posts.Add(new Post() { Content = "", Id = 1 });
                await dbContext.SaveChangesAsync();
            }

            PostService postService = new PostService(dbContext);

            var result = postService.WritePost(new Post(), "1").Result;
            Assert.False(result);
        }

        [Fact]
        public async void WriteComment_Succes()
        {
            var options = new DbContextOptionsBuilder<BlogDbContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
                  .Options;

            var dbContext = new BlogDbContext(options);
            dbContext.Database.EnsureCreated();

            if (await dbContext.Posts.CountAsync() <= 0)
            {
                dbContext.Posts.Add(new Post() { Content = "", Id = 1 });
                await dbContext.SaveChangesAsync();
            }

            PostService postService = new PostService(dbContext);

            var result = postService.WriteComment(new Comment() { IdPost = 1 }).Result;
            Assert.True(result);
        }

        [Fact]
        public async void WriteComment_Fail()
        {
            var options = new DbContextOptionsBuilder<BlogDbContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
                  .Options;

            var dbContext = new BlogDbContext(options);
            dbContext.Database.EnsureCreated();

            if (await dbContext.Posts.CountAsync() <= 0)
            {
                dbContext.Posts.Add(new Post() { Content = "", Id = 2 });
                await dbContext.SaveChangesAsync();
            }

            PostService postService = new PostService(dbContext);

            var result = postService.WriteComment(new Comment() { IdPost = 1 }).Result;
            Assert.False(result);
        }

        [Fact]
        public async void UpdateComment_Succes()
        {
            var options = new DbContextOptionsBuilder<BlogDbContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
                  .Options;

            var dbContext = new BlogDbContext(options);
            dbContext.Database.EnsureCreated();

            if (await dbContext.Posts.CountAsync() <= 0)
            {
                dbContext.Comments.Add(new Comment() { Text = "", Id = 1 });
                await dbContext.SaveChangesAsync();
            }

            PostService postService = new PostService(dbContext);

            var result = postService.UpdateComment(new Comment() { Id = 1 }).Result;
            Assert.True(result);
        }

        [Fact]
        public async void UpdateComment_Fail()
        {
            var options = new DbContextOptionsBuilder<BlogDbContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
                  .Options;

            var dbContext = new BlogDbContext(options);
            dbContext.Database.EnsureCreated();

            if (await dbContext.Posts.CountAsync() <= 0)
            {
                dbContext.Comments.Add(new Comment() { Text = "", Id = 1 });
                await dbContext.SaveChangesAsync();
            }

            PostService postService = new PostService(dbContext);

            var result = postService.UpdateComment(new Comment() { Id = 2 }).Result;
            Assert.False(result);
        }

        [Fact]
        public async void GetPassedPost_Succes()
        {
            var options = new DbContextOptionsBuilder<BlogDbContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
                  .Options;

            var dbContext = new BlogDbContext(options);
            dbContext.Database.EnsureCreated();

            if (await dbContext.Posts.CountAsync() <= 0)
            {
                dbContext.Posts.Add(new Post() { Content = "", IdUser = 1, Passed = true });
                dbContext.Users.Add(new User() { Id = 1, UserName = "" });
                await dbContext.SaveChangesAsync();
            }

            PostService postService = new PostService(dbContext);

            var result = postService.GetPassedPost();
            Assert.True(result.Count > 0);
        }

        [Fact]
        public async void GetPassedPost_NoContent()
        {
            var options = new DbContextOptionsBuilder<BlogDbContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
                  .Options;

            var dbContext = new BlogDbContext(options);
            dbContext.Database.EnsureCreated();

            if (await dbContext.Posts.CountAsync() <= 0)
            {
                dbContext.Posts.Add(new Post() { IdUser = 1, Content = "" });
                await dbContext.SaveChangesAsync();
            }

            PostService postService = new PostService(dbContext);

            var result = postService.GetPassedPost();
            Assert.False(result.Count > 0);
        }

        [Fact]
        public async void GetNotPassedPost_Succes()
        {
            var options = new DbContextOptionsBuilder<BlogDbContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
                  .Options;

            var dbContext = new BlogDbContext(options);
            dbContext.Database.EnsureCreated();

            if (await dbContext.Posts.CountAsync() <= 0)
            {
                dbContext.Posts.Add(new Post() { Content = "", Id = 1, Passed = false });
                await dbContext.SaveChangesAsync();
            }

            PostService postService = new PostService(dbContext);

            var result = postService.GetNotPassedPost().Result;
            Assert.True(result.Count > 0);
        }

        [Fact]
        public async void GetNotPassedPost_NoContent()
        {
            var options = new DbContextOptionsBuilder<BlogDbContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
                  .Options;

            var dbContext = new BlogDbContext(options);
            dbContext.Database.EnsureCreated();

            if (await dbContext.Posts.CountAsync() <= 0)
            {
                dbContext.Posts.Add(new Post() { Content = "", Id = 1 });
                await dbContext.SaveChangesAsync();
            }

            PostService postService = new PostService(dbContext);

            var result = postService.GetNotPassedPost().Result;
            Assert.True(result.Count == 0);
        }

        [Fact]
        public async void ApprovePost_Succes()
        {
            var options = new DbContextOptionsBuilder<BlogDbContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
                  .Options;

            var dbContext = new BlogDbContext(options);
            dbContext.Database.EnsureCreated();

            if (await dbContext.Posts.CountAsync() <= 0)
            {
                dbContext.Posts.Add(new Post() { Content = "", Id = 1 });
                await dbContext.SaveChangesAsync();
            }

            PostService postService = new PostService(dbContext);

            var result = postService.ApprovePost(1).Result;
            Assert.True(result);
        }

        [Fact]
        public async void ApprovePost_Fail()
        {
            var options = new DbContextOptionsBuilder<BlogDbContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
                  .Options;

            var dbContext = new BlogDbContext(options);
            dbContext.Database.EnsureCreated();

            if (await dbContext.Posts.CountAsync() <= 0)
            {
                dbContext.Posts.Add(new Post() { Content = "", Id = 1 });
                await dbContext.SaveChangesAsync();
            }

            PostService postService = new PostService(dbContext);

            var result = postService.ApprovePost(2).Result;
            Assert.False(result);
        }

        [Fact]
        public async void DeletePost_Catch()
        {
            var options = new DbContextOptionsBuilder<BlogDbContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
                  .Options;

            var dbContext = new BlogDbContext(options);
            dbContext.Database.EnsureCreated();

            if (await dbContext.Posts.CountAsync() <= 0)
            {
                dbContext.Posts.Add(new Post() { Content = "", Id = 1 });
                await dbContext.SaveChangesAsync();
            }

            PostService postService = new PostService(dbContext);

            var result = postService.DeletePost(1).Result;
            Assert.False(result);
        }
    }
}
