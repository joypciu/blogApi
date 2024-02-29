using System.ComponentModel.DataAnnotations;

namespace api;

public class CommentDto
{
    
    public int Id { get; set; }
    public string Content { get; set; }
    public string CommentedOn { get; set; }
    public int PostId { get; set; }

}
