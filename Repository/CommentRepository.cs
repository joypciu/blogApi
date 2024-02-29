
using api.Dtos;
using Microsoft.EntityFrameworkCore;

namespace api;

public class CommentRepository : ICommentRepository
{
    private readonly Context _context;
    public CommentRepository(Context context)
    {
            _context = context;
        
    }

    public async Task<List<Comment>> GetAllCommentsAsync()
    {
        return await _context.Comments.ToListAsync();
    }

    public Task<Comment> GetCommentByIdAsync(int id)
    {
       var comment = _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
       return comment;
    }
     public async Task<Comment> CreateCommentAsync(Comment comment)
    {
        await _context.Comments.AddAsync(comment);
        await _context.SaveChangesAsync();
        return comment;
        
    }

    public async Task<Comment> UpdateCommentAsync(int commentToUpdate,Comment updatedComment)
    {
        var comment = await _context.Comments.FindAsync(commentToUpdate);
        comment.Content = updatedComment.Content;
        await _context.SaveChangesAsync();
        return comment;
    }

    public async Task DeleteCommentAsync(Comment comment)
    {
        _context.Comments.Remove(comment);
        await _context.SaveChangesAsync();
    }

   
}
