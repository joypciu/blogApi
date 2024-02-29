using api.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api;

[ApiController]
[Route("api/comments")]
public class CommentController : ControllerBase
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;
    private readonly IPostRepository _postRepository;
    public CommentController(ICommentRepository commentRepository, IMapper mapper, IPostRepository postRepository)
    {
            _postRepository = postRepository;
            _commentRepository = commentRepository;
            _mapper = mapper;
        
    }
    [HttpGet]
    public async Task<IActionResult> GetAllComments()
    {
        var comments = await _commentRepository.GetAllCommentsAsync();
        return Ok(_mapper.Map<List<CommentDto>>(comments));

    }
    [HttpGet("{commentId:int}")]
    public async Task<ActionResult<CommentDto>> GetCommentById(int commentId){
        var comment = await _commentRepository.GetCommentByIdAsync(commentId);
        if(comment == null) return NotFound();
        return _mapper.Map<CommentDto>(comment);
    }
    [HttpPost("{postId:int}")]
    public async Task<IActionResult> CreateComment(int postId,[FromBody] CreateCommentDto createCommentDto){
         if(!ModelState.IsValid){
            return BadRequest(ModelState);
        }
        var post = await _postRepository.GetPostByIdAsync(postId);
        if(post == null) return NotFound();

        var comment = _mapper.Map<Comment>(createCommentDto);
        comment.PostId = postId;
        var result = await _commentRepository.CreateCommentAsync(comment);
        return CreatedAtAction(nameof(GetCommentById), new {commentId = result.Id}, _mapper.Map<CommentDto>(result));
    }
    [HttpPut("{commentIdToUpdate:int}")]
    public async Task<IActionResult> UpdateComment(int commentIdToUpdate,[FromBody] UpdateCommentDto commentDto)
    {
        var comment = await _commentRepository.GetCommentByIdAsync(commentIdToUpdate);
        if(comment == null){
            return NotFound("Comment not exist. what are you doing??");
        }
        var updateCommentToDatabase = _mapper.Map<Comment>(commentDto) ;
        var updatedComment = await _commentRepository.UpdateCommentAsync(commentIdToUpdate,updateCommentToDatabase);
    
        return CreatedAtAction(nameof(GetCommentById),new {commentId=commentIdToUpdate}, _mapper.Map<CommentDto>(updatedComment));
    }
    [HttpDelete("{commentId:int}")]
    public async Task<IActionResult> DeleteComment(int commentId){
        var comment = await _commentRepository.GetCommentByIdAsync(commentId);
        if(comment == null) return NotFound();
        await _commentRepository.DeleteCommentAsync(comment);
        var comments = await _commentRepository.GetAllCommentsAsync();
        return CreatedAtAction(nameof(GetAllComments), _mapper.Map<List<CommentDto>>(comments));
    }

}
