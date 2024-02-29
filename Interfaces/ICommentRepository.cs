namespace api;

public interface ICommentRepository
{
     Task<List<Comment>> GetAllCommentsAsync();
     Task<Comment> GetCommentByIdAsync(int id);
     Task<Comment> CreateCommentAsync(Comment comment);
     Task<Comment> UpdateCommentAsync(int commentId,Comment comment);
     Task DeleteCommentAsync(Comment comment);
}
