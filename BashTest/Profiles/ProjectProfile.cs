using BashTest.Dto;
using BashTest.Model;
using AutoMapper;

namespace BashTest.Profiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<ProjectCreateDto, Project>();
        }
    }
}
