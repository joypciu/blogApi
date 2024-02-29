using System.ComponentModel.DataAnnotations;

namespace api.Dtos
{
    public class UpdateCommentDto
    {
   
    [Required]
    [MinLength(5, ErrorMessage = "Content must be at least 5 characters long")]
    [MaxLength(100, ErrorMessage = "Content must be at most 100 characters long")]
    public string Content { get; set; }
   
        
    }
}