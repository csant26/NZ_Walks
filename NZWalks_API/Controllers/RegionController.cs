using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks_API.Data;
using NZWalks_API.Models.Domain;
using NZWalks_API.Models.DTO;
using NZWalks_API.Repository;

namespace NZWalks_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly NZWalksDbContext _context;
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionController(NZWalksDbContext context, IRegionRepository regionRepository, IMapper mapper)
        {
            _context = context;
            _regionRepository = regionRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Get data from database - Models
            var regions = await _regionRepository.GetAllAsync();

            //Map Models to DTOs
            //var regionsDTO = new List<RegionDTO>();
            //foreach(var region in regions)
            //{
            //    regionsDTO.Add(new RegionDTO()
            //    {
            //        Id = region.Id,
            //        Name = region.Name,
            //        Code = region.Code,
            //        RegionImageUrl = region.RegionImageUrl,
            //    });
            //}
            var regionsDTO = _mapper.Map<List<RegionDTO>>(regions);


            //Return DTOs
            return Ok(regionsDTO);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {
            var region = await _regionRepository.GetByIdAsync(id);
            if (region == null)
            {
                return NotFound();
            }

            //var regionDTO = new RegionDTO() 
            //{Id=region.Id,Code=region.Code,Name=region.Name,RegionImageUrl=region.RegionImageUrl};
            var regionDTO = _mapper.Map<RegionDTO>(region);

            return Ok(regionDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]AddRegionRequestDTO addregionDTO)
        {
            //DTO to Model
            //Region region = new Region() 
            //{Code = addregionDTO.Code, Name = addregionDTO.Name, RegionImageUrl = addregionDTO.RegionImageUrl };

            var region = _mapper.Map<Region>(addregionDTO);

            //Model to Database
            region = await _regionRepository.CreateRegionAsync(region);

            //Model back to DTO in order to pass to client
            //RegionDTO regionDTO = new RegionDTO() 
            //{Id=region.Id, Name=region.Name,Code=region.Code,RegionImageUrl=region.RegionImageUrl };
            RegionDTO regionDTO = _mapper.Map<RegionDTO>(region);


            //201 response instead of 200
            return CreatedAtAction(nameof(GetById), new { id = region.Id},regionDTO);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute]Guid id,[FromBody] UpdateRegionRequestDTO updateregionDTO)
        {
            //Map DTOs to Model
            //Region updatedRegion = new Region
            //{
            //    Code = updateregionDTO.Code,
            //    Name = updateregionDTO.Name,
            //    RegionImageUrl = updateregionDTO.RegionImageUrl
            //};

            Region updatedRegion = _mapper.Map<Region>(updateregionDTO);

            //Pass model to repository
            updatedRegion = await _regionRepository.UpdateRegionAsync(id, updatedRegion);

            if (updatedRegion == null) { return NotFound(); }

            //RegionDTO regionDTO = new RegionDTO()
            //{ Id = updatedRegion.Id, Name = updatedRegion.Name, Code = updatedRegion.Code, RegionImageUrl = updatedRegion.RegionImageUrl };
            RegionDTO regionDTO = _mapper.Map<RegionDTO>(updatedRegion);


            return Ok(regionDTO);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            var region = await _regionRepository.DeleteByIdAsync(id);

            if (region == null) { return NotFound(); }

            //RegionDTO regionDTO = new RegionDTO()
            //{ Id = region.Id, Name = region.Name, Code = region.Code, RegionImageUrl = region.RegionImageUrl };

            RegionDTO regionDTO = _mapper.Map<RegionDTO>(region);

            return Ok(regionDTO);
        }
    }
}
