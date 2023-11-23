using CantThinkOfATitle.DTOs;
using CantThinkOfATitle.Models;
using CantThinkOfATitle.Responses;

namespace CantThinkOfATitle.Services.Interfaces
{
    public interface IPostService
    {
        Task<PostResponse<List<PostResponseDTO>>> GetAllPosts();

        //Task<PostResponse<PostResponseDTO>> GetPostsByUser(string email);

        //Task<PostResponse<PostResponseDTO>> CreatePost(User user);

        //Task<PostResponse<PostResponseDTO>> UpdatePost(PostDTO post, string email);

        //Task<PostResponse<PostResponseDTO>> DeletePost(string email);
    }
}
