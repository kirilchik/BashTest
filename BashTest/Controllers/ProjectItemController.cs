using AutoMapper;
using BashTest.Dto;
using BashTest.Model;
using BashTest.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BashTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectItemController : ControllerBase
    {
        private readonly IRepository<ProjectItem> _projectItemRepository;
        private readonly IMapper _mapper;

        public ProjectItemController(IRepository<ProjectItem> projectItemRepository, IMapper mapper)
        {
            _projectItemRepository = projectItemRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectItem>> GetByIdAsync(int id)
        {
            var project = await _projectItemRepository.GetByIdAsync(id);
            return Ok(project);
        }

        [HttpGet]
        public async Task<ActionResult<ProjectItemViewDto>> GetAll()
        {
            var projectItems = await _projectItemRepository.GetManyAsync(includeProperties: new string[] { "Children" });
            var projectItemsDto = _mapper.Map<IEnumerable<ProjectItemViewDto>>(projectItems);
            return Ok(projectItemsDto.Where(x => x.ParentId == null));
        }

        [HttpGet("GetDetailByProjectId/{id}")]
        public async Task<ActionResult<List<DetailViewDto>>> GetDetailByProjectId(int id)
        {
            var items = await _projectItemRepository.GetManyAsync(filter: x => x.ProjectId == id,
                includeProperties: new string[] { "Project", "Parent", "DocumentsItems", "DocumentsItems.DocumentsPack", "DocumentsItems.DocumentsPack.Mark" });

            return Ok(FillDetails(items));
        }

        [HttpGet("GetDetailByItemId/{id}")]
        public async Task<ActionResult<List<DetailViewDto>>> GetDetailByItemId(int id)
        {
            var items = await _projectItemRepository.GetManyAsync(filter: x => x.Id == id,
                includeProperties: new string[] { "Project", "Parent", "DocumentsItems", "DocumentsItems.DocumentsPack", "DocumentsItems.DocumentsPack.Mark" });

            return Ok(FillDetails(items));
        }

        private List<DetailViewDto> FillDetails(List<ProjectItem> items)
        {
            return items.SelectMany(d => d.DocumentsItems)
                .Select((x, index) => new DetailViewDto
                {
                    Shifr = x.ProjectItem.Project.Shifr,
                    Code = $"{x.ProjectItem.Parent?.Code}.{x.ProjectItem?.Code}",
                    Marka = x.DocumentsPack.Mark.ShortName,
                    Number = $"{index}.{x.DocumentsPack.Mark.ShortName}-{x.DocumentsPack.Number}",
                    FullShifr = $"{x.ProjectItem?.Project.Shifr}.{x.ProjectItem?.Parent?.Code}.{x.ProjectItem?.Code}-{x.DocumentsPack.Mark.ShortName}{x.DocumentsPack.Number}"
                }).ToList();
        }
    }
}
