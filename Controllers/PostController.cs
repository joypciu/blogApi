using System.Security.Cryptography;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api;

[ApiController]
[Route("api/posts")]
public class PostController : ControllerBase
{
    public readonly IMapper _mapper;
    private readonly IPostRepository _postRepository;

    public PostController(IMapper mapper, IPostRepository postRepository)
    {
            _postRepository = postRepository;
            _mapper = mapper;
    }
  
    [HttpGet]
    public async Task<ActionResult<List<PostDto>>> GetAllPosts(){
        var posts = await _postRepository.GetAllPostAsync();
        var result = _mapper.Map<List<PostDto>>(posts);
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async  Task<IActionResult> GetPostById(int id){
        var post = await _postRepository.GetPostByIdAsync(id);
        if(post == null){
            return NoContent();
        }
        var result = _mapper.Map<PostDto>(post);
        return Ok(result);
    }

    [HttpPost]
    public async  Task<IActionResult> CreatePost(PostDto postDto){
         if(!ModelState.IsValid){
            return BadRequest(ModelState);
        }
        var postToCreate = _mapper.Map<Post>(postDto);    
        var post = await _postRepository.AddPostAsync(postToCreate);
        return CreatedAtAction(nameof(GetPostById), new { id = post.Id }, post);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdatePostById(int id,[FromBody] PostDto postDto){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var post = await _postRepository.UpdatePostAsync(postDto, id);
            if(post == null){
                return NoContent();
            }
            return CreatedAtAction(nameof(GetPostById), new { id = post.Id }, post);   
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeletePostById(int id){
        var post = await _postRepository.GetPostByIdAsync(id);
        if(post == null){
           return NoContent();
        }
        else{
            await _postRepository.DeletePost(post);
            var posts = await _postRepository.GetAllPostAsync();
            return CreatedAtAction(nameof(GetAllPosts), _mapper.Map<List<PostDto>>(posts));
        }
    }

}
