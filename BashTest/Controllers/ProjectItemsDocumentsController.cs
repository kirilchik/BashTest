using AutoMapper;
using BashTest.Dto;
using BashTest.Model;
using BashTest.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BashTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectItemsDocumentsController : ControllerBase
    {
        private readonly IRepository<ProjectItemsDocuments> _projectItemsDocumentsRepository;
        private readonly IMapper _mapper;

        public ProjectItemsDocumentsController(IRepository<ProjectItemsDocuments> projectItemsDocumentsRepository, IMapper mapper)
        {
            _projectItemsDocumentsRepository = projectItemsDocumentsRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ProjectItemsDocuments>> GetAll()
        {
            var projectItemsDocuments = await _projectItemsDocumentsRepository.GetAllAsync();
            return Ok(projectItemsDocuments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectItemsDocuments>> GetByIdAsync(int id)
        {
            var projectItemsDocument = await _projectItemsDocumentsRepository.GetByIdAsync(id);
            return Ok(projectItemsDocument);
        }

        [HttpPost]
        public async Task<ActionResult<ProjectItemsDocuments>> AddAsync(ProjectItemsDocumentsCreateDto projectItemsDocument)
        {
            await _projectItemsDocumentsRepository.AddAsync(_mapper.Map<ProjectItemsDocuments>(projectItemsDocument));
            bool added = await _projectItemsDocumentsRepository.Save();
            if (added)
                return Ok(projectItemsDocument);

            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult<ProjectItemsDocuments>> UpdateAsync(ProjectItemsDocumentsUpdateDto projectItemsDocument)
        {
            await _projectItemsDocumentsRepository.Update(_mapper.Map<ProjectItemsDocuments>(projectItemsDocument));
            bool added = await _projectItemsDocumentsRepository.Save();
            if (added)
                return Ok(projectItemsDocument);

            return BadRequest();
        }


    }
}
