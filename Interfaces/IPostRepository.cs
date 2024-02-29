using Microsoft.AspNetCore.Mvc;

namespace api;

public interface IPostRepository
{
    Task<List<Post>> GetAllPostAsync();
    Task<Post> GetPostByIdAsync(int id);
    Task<Post> AddPostAsync(Post post);
    Task<Post> UpdatePostAsync(PostDto postDto, int id);
    Task DeletePost(Post post);

}
