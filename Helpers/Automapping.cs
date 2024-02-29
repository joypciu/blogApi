using api.Dtos;
using AutoMapper;

namespace api;

// write automapper code here
public class Automapping : Profile
{
    public Automapping()
    {
        CreateMap<Post, PostDto>()
        .ForMember(des => des.Comments, src => src.MapFrom(p => p.Comments))
        .ReverseMap();
        CreateMap<Comment, CommentDto>()
            .ForMember(dest => dest.CommentedOn, src => src.MapFrom(c => c.CommentedOn.ToUniversalTime().ToString("dd/mm/yyyy hh:mm tt")))
            .ReverseMap();
        CreateMap<CreateCommentDto, Comment>();
        CreateMap<UpdateCommentDto,Comment>();

     
    }
}

