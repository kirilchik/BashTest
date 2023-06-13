using BashTest.Dto;
using BashTest.Model;
using AutoMapper;

namespace BashTest.Profiles
{
    public class ProjectItemsDocumentsProfile : Profile
    {
        public ProjectItemsDocumentsProfile()
        {
            CreateMap<ProjectItemsDocumentsCreateDto, ProjectItemsDocuments>();
            CreateMap<ProjectItemsDocumentsUpdateDto, ProjectItemsDocuments>();            
        }
    }
}
