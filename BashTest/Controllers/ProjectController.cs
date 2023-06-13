using AutoMapper;
using BashTest.Dto;
using BashTest.Model;
using BashTest.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BashTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IRepository<Project> _projectRepository;
        private readonly IMapper _mapper;

        public ProjectController(IRepository<Project> projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Project>> GetAll()
        {
            var projects = await _projectRepository.GetAllAsync();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetByIdAsync(int id)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            return Ok(project);
        }

        [HttpPost]
        public async Task<ActionResult<Project>> AddAsync(ProjectCreateDto project)
        {
            await _projectRepository.AddAsync(_mapper.Map<Project>(project));
            bool added = await _projectRepository.Save();
            if (added)
                return Ok(project);

            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult<Project>> UpdateAsync(Project project)
        {
            await _projectRepository.Update(project);
            bool added = await _projectRepository.Save();
            if (added)
                return Ok(project);

            return BadRequest();
        }
    }
}
