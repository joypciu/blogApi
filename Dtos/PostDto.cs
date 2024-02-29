using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;

namespace api;

public class PostDto
{
    public int Id { get; set; }
    [Required]
    [MinLength(10, ErrorMessage = "Title must be at least 10 characters long")]
    [MaxLength(50, ErrorMessage = "Title must be at most 50 characters long")]
    public string Title { get; set; }
    [Required]
    [MinLength(15, ErrorMessage = "Content must be at least 15 characters long")]
    [MaxLength(200, ErrorMessage = "Content must be at most 200 characters long")]
    public string Content { get; set; }
    public string CreatedOn { get; set;}
    public List<CommentDto> Comments { get; set; }

    

  
}
