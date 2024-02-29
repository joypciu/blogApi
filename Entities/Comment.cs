namespace api;

public class Comment
{
    public int Id { get; set; }
    public string Content { get; set; }
    public DateTime CommentedOn { get; set; } = DateTime.UtcNow;
    public int PostId { get; set; }
    public Post Post { get; set; }

}
  