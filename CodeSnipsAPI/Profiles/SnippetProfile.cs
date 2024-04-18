using AutoMapper;

namespace CodeSnipsAPI.Profiles
{
    public class SnippetProfile : Profile
    {
        public SnippetProfile() 
        {
            CreateMap<Entites.Snippet, Models.SnippetDto>();
            CreateMap<Models.SnippetForCreationDto, Entites.Snippet>();
            
        }
    }
}
