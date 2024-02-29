namespace api;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string  Content { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    // var yourDateTimeObject = DateTime.SpecifyKind(yourDateTime, DateTimeKind.Utc);

    public List<Comment> Comments { get; set; }

}
