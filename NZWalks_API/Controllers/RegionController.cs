using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks_API.Data;
using NZWalks_API.Models.Domain;
using NZWalks_API.Models.DTO;

namespace NZWalks_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly NZWalksDbContext _context;
        public RegionController(NZWalksDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            //Get data from database - Models
            var regions = _context.Regions.ToList();

            //Map Models to DTOs
            var regionsDTO = new List<RegionDTO>();
            foreach(var region in regions)
            {
                regionsDTO.Add(new RegionDTO()
                {
                    Id = region.Id,
                    Name = region.Name,
                    Code = region.Code,
                    RegionImageUrl = region.RegionImageUrl,
                });
            }

            //Return DTOs
            return Ok(regionsDTO);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute]Guid id)
        {
            var region = _context.Regions.Find(id);
            if (region == null)
            {
                return NotFound();
            }

            var regionDTO = new RegionDTO() 
            {Id=region.Id,Code=region.Code,Name=region.Name,RegionImageUrl=region.RegionImageUrl};
            
            return Ok(regionDTO);
        }
        [HttpPost]
        public IActionResult Create([FromBody]AddRegionRequestDTO addregionDTO)
        {
            //DTO to Model
            Region region = new Region() 
            {Code = addregionDTO.Code, Name = addregionDTO.Name, RegionImageUrl = addregionDTO.RegionImageUrl };

            //Model to Database
            _context.Regions.Add(region);
            _context.SaveChanges();

            //Model back to DTO in order to pass to client
            RegionDTO regionDTO = new RegionDTO() 
            {Id=region.Id, Name=region.Name,Code=region.Code,RegionImageUrl=region.RegionImageUrl };

            //201 response instead of 200
            return CreatedAtAction(nameof(GetById), new { id = region.Id},regionDTO);
        }
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute]Guid id,[FromBody] UpdateRegionRequestDTO updateregionDTO)
        {
            Region region = _context.Regions.Find(id);

            if(region==null) { return NotFound(); }

            region.Code = updateregionDTO.Code;
            region.Name = updateregionDTO.Name;
            region.RegionImageUrl = updateregionDTO.RegionImageUrl;

            _context.SaveChanges();

            RegionDTO regionDTO = new RegionDTO()
            { Id = region.Id, Name = region.Name, Code = region.Code, RegionImageUrl = region.RegionImageUrl };

            return Ok(regionDTO);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]Guid id)
        {
            var region = _context.Regions.Find(id);
            if(region==null){ return NotFound(); }
            _context.Regions.Remove(region);
            _context.SaveChanges();

            RegionDTO regionDTO = new RegionDTO()
            { Id = region.Id, Name = region.Name, Code = region.Code, RegionImageUrl = region.RegionImageUrl };
            
            return Ok(regionDTO);
        }
    }
}
