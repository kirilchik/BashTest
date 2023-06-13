using AutoMapper;
using BashTest.Dto;
using BashTest.Model;
using BashTest.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BashTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentsPackController : ControllerBase
    {
        private readonly IRepository<DocumentsPack> _documentsPackRepository;
        private readonly IMapper _mapper;

        public DocumentsPackController(IRepository<DocumentsPack> documentsPackRepository, IMapper mapper)
        {
            _documentsPackRepository = documentsPackRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<DocumentsPack>> GetAll()
        {
            var documentsPacks = await _documentsPackRepository.GetAllAsync();
            return Ok(documentsPacks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentsPack>> GetByIdAsync(int id)
        {
            var documentsPack = await _documentsPackRepository.GetByIdAsync(id);
            return Ok(documentsPack);
        }

        [HttpPost]
        public async Task<ActionResult<DocumentsPack>> AddAsync(DocumentsPackCreateDto documentPack)
        {
            await _documentsPackRepository.AddAsync(_mapper.Map<DocumentsPack>(documentPack));
            bool added = await _documentsPackRepository.Save();
            if (added)
                return Ok(documentPack);

            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult<DocumentsPack>> UpdateAsync(DocumentsPack documentPack)
        {
            await _documentsPackRepository.Update(documentPack);
            bool added = await _documentsPackRepository.Save();
            if (added)
                return Ok(documentPack);

            return BadRequest();
        }
    }
}
