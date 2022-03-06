﻿
using Data.Models;

namespace Application.Services.Interface
{
    public interface IPostService
    {
        Task<bool> WritePost(Post post, string userId);
        Task<bool> WriteComment(Comment comment);
        Task<bool> UpdateComment(Comment comment);
        object GetPassedPost();
        Task<List<Post>> GetNotPassedPost();
        Task<bool> ApprovePost(int postId);
        Task<bool> DeletePost(int postId);
    }
}
