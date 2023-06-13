using AutoMapper;
using BashTest.Dto;
using BashTest.Model;
using BashTest.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BashTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MarkController : ControllerBase
    {
        private readonly IRepository<Mark> _markRepository;
        private readonly IMapper _mapper;

        public MarkController(IRepository<Mark> markRepository, IMapper mapper)
        {
            _markRepository = markRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Mark>> GetAll()
        {
            var marks = await _markRepository.GetAllAsync();
            return Ok(marks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Mark>> GetByIdAsync(int id)
        {
            var mark = await _markRepository.GetByIdAsync(id);
            return Ok(mark);
        }

        [HttpPost]
        public async Task<ActionResult<Mark>> AddAsync(MarkCreateDto mark)
        {
            await _markRepository.AddAsync(_mapper.Map<Mark>(mark));
            bool added = await _markRepository.Save();
            if (added)
                return Ok(mark);

            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult<Mark>> UpdateAsync(Mark mark)
        {
            await _markRepository.Update(mark);
            bool added = await _markRepository.Save();
            if (added)
                return Ok(mark);

            return BadRequest();
        }
    }
}
