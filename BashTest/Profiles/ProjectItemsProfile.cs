using BashTest.Dto;
using BashTest.Model;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace BashTest.Profiles
{
    public class ProjectItemsProfile : Profile
    {
        public ProjectItemsProfile()
        {
            CreateMap<ProjectItem, ProjectItemViewDto>();
        }
    }
}
