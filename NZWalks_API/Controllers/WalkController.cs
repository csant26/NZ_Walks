using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks_API.CustomActionFilter;
using NZWalks_API.Models.Domain;
using NZWalks_API.Models.DTO;
using NZWalks_API.Repository;

namespace NZWalks_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalkController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWalkRepository _repository;

        public WalkController(IMapper mapper, IWalkRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDTO addWalkRequestDTO)
        {
            Walk walk = _mapper.Map<Walk>(addWalkRequestDTO);

            walk = await _repository.CreateAsync(walk);

            return Ok(_mapper.Map<WalkDTO>(walk));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var walks = await _repository.GetAllAsync();

            return Ok(_mapper.Map<List<WalkDTO>>(walks));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            Walk walk = await _repository.GetByIdAsync(id);

            if (walk == null) { return NotFound(); }

            return Ok(_mapper.Map<WalkDTO>(walk));
        }
        [HttpPut("{id}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateByIdAsync([FromRoute] Guid id, [FromBody] UpdateWalkRequestDTO updateWalkRequestDTO)
        {
            Walk walk = _mapper.Map<Walk>(updateWalkRequestDTO);


            walk = await _repository.UpdateByIdAsync(id, walk);

            if (walk == null) { return NotFound(); }

            return Ok(_mapper.Map<WalkDTO>(walk));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteByIdAsync([FromRoute] Guid id)
        {
            Walk walk = await _repository.DeleteByIdAsync(id);

            if (walk == null) { return NotFound(); }

            return Ok(_mapper.Map<WalkDTO>(walk));
        }
    }
}
