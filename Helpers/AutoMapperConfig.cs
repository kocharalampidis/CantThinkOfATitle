using AutoMapper;
using CantThinkOfATitle.DTOs;
using CantThinkOfATitle.Models;

namespace CantThinkOfATitle.Helpers
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<UserResponseDTO, User>().ReverseMap();
            CreateMap<UserDTO, User>().ReverseMap();
            
            CreateMap<PostResponseDTO, Posts>().ReverseMap();
            CreateMap<PostDTO, Posts>().ReverseMap();

        }
    }
}
