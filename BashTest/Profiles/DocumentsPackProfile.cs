using BashTest.Dto;
using BashTest.Model;
using AutoMapper;

namespace BashTest.Profiles
{
    public class DocumentsPackProfile : Profile
    {
        public DocumentsPackProfile()
        {
            CreateMap<DocumentsPackCreateDto, DocumentsPack>();
        }
    }
}
