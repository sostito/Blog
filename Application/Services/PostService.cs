using Data.Models;
using Data.Context;
using Application.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class PostService : IPostService
    {
        private readonly BlogDbContext blogDbContext;

        public PostService(BlogDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
        }

        public async Task<bool> WritePost(Post post, string userId)
        {
            try
            {
                post.DatePassed = null;
                post.Passed = false;
                post.IdUser = Convert.ToInt16(userId);
                blogDbContext.Add(post);
                var result = await blogDbContext.SaveChangesAsync();
                return result > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> WriteComment(Comment comment)
        {
            try
            {
                var valid = await blogDbContext.Posts.AnyAsync(x => x.Id == comment.IdPost);

                if (valid)
                {
                    blogDbContext.Add(comment);
                    var result = await blogDbContext.SaveChangesAsync();
                    return result > 0;
                }
                return false;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateComment(Comment comment)
        {
            try
            {
                var valid = await blogDbContext.Comments.AnyAsync(x => x.Id == comment.Id);

                if (valid)
                {
                    var commentDb = await blogDbContext.Comments.FirstAsync(x => x.Id == comment.Id);
                    commentDb.Text = comment.Text;
                    blogDbContext.Update(commentDb);
                    var result = await blogDbContext.SaveChangesAsync();
                    return result > 0;
                }
                return false;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public object GetPassedPost()
        {
            try
            {
                var postList = blogDbContext.Posts
                    .Join(
                    blogDbContext.Users,
                    Post => Post.IdUser,
                    User => User.Id,
                    (post, user) => new
                    {
                        Comment = post.Content,
                        Author = user.UserName,
                        ApprobalDate = post.DatePassed
                    }
                 ).ToList();

                return postList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Post>> GetNotPassedPost()
        {
            try
            {
                var postList = await blogDbContext.Posts.Where(post => post.Passed == false).ToListAsync();
                return postList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> ApprovePost(int postId)
        {
            try
            {
                var existe = await blogDbContext.Posts.AnyAsync(x => x.Id == postId);

                if (existe)
                {
                    var post = await blogDbContext.Posts.FirstAsync(x => x.Id == postId);
                    post.Passed = true;
                    post.DatePassed = DateTime.Now;
                    blogDbContext.Update(post);
                    await blogDbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeletePost(int postId)
        {
            try
            {
                var existe = await blogDbContext.Posts.AnyAsync(x => x.Id == postId);

                if (existe)
                {
                    blogDbContext.Remove(new Post() { Id = postId });
                    await blogDbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
