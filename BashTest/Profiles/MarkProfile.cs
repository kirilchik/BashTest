using AutoMapper;
using BashTest.Dto;
using BashTest.Model;

namespace BashTest.Profiles
{
    public class MarkProfile : Profile
    {
        public MarkProfile()
        {
            CreateMap<MarkCreateDto, Mark>();
        }
    }
}
