
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api;

public class PostRepository : IPostRepository
{
    private readonly Context _context;
    public PostRepository(Context context)
    {
            _context = context;
        
    }

    public async Task<List<Post>> GetAllPostAsync()
    {
      return await _context.Posts.Include(p => p.Comments).ToListAsync();
       
     
    }

    public async Task<Post> GetPostByIdAsync(int id)
    {
        return await _context.Posts.Include(p => p.Comments).FirstOrDefaultAsync(p => p.Id == id);
    }
    public async Task<Post> AddPostAsync(Post post)
    {
        await _context.Posts.AddAsync(post);
        await _context.SaveChangesAsync();
        return post;
    }

    public async Task<Post> UpdatePostAsync(PostDto postDto, int id)
    {
        var postExist = await _context.Posts.FindAsync(id);
        if(postExist == null){
            return null;
        }
        else{
            postExist.Title = postDto.Title;
            postExist.Content = postDto.Content;
            await _context.SaveChangesAsync();
            return postExist;
        }
        
       
    }

    public async Task DeletePost(Post post)
    {
        _context.Posts.Remove(post);
        await _context.SaveChangesAsync();
       
    }

  
}
