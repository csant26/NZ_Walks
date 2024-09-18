using Microsoft.EntityFrameworkCore;
using NZWalks_API.Data;
using NZWalks_API.Models.Domain;
using NZWalks_API.Models.DTO;

namespace NZWalks_API.Repository
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext _context;
        public RegionRepository(NZWalksDbContext context)
        {
            _context = context;
        }
        public async Task<List<Region>> GetAllAsync()
        {
            return await _context.Regions.ToListAsync();
        }
        public async Task<Region?> GetByIdAsync(Guid id)
        {
            return await _context.Regions.FindAsync(id);
        }
        public async Task<Region> CreateRegionAsync(Region region)
        {
            await _context.Regions.AddAsync(region);
            await _context.SaveChangesAsync();
            return region;
        }
        public async Task<Region?> UpdateRegionAsync(Guid id, Region updatedRegion)
        {
            Region existingRegion = await GetByIdAsync(id);

            if (existingRegion == null) { return null; }

            existingRegion.Code = updatedRegion.Code;
            existingRegion.Name = updatedRegion.Name;
            existingRegion.RegionImageUrl = updatedRegion.RegionImageUrl;

            await _context.SaveChangesAsync();

            return existingRegion;
        }

        public async Task<Region?> DeleteByIdAsync(Guid id)
        {
            var existingRegion = await GetByIdAsync(id);
            if (existingRegion == null) { return null; }
            _context.Regions.Remove(existingRegion);
            await _context.SaveChangesAsync();
            return existingRegion;
        }
    }
}
