using Microsoft.EntityFrameworkCore;
using NZWalks_API.Data;
using NZWalks_API.Models.Domain;

namespace NZWalks_API.Repository
{
    public class WalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext _context;

        public WalkRepository(NZWalksDbContext context)
        {
            _context = context;
        }
        public async Task<Walk> CreateAsync(Walk walk)
        {
            await _context.Walks.AddAsync(walk);
            await _context.SaveChangesAsync();
            return walk;
        }

        public async Task<List<Walk>> GetAllAsync()
        {
            //For type-safety, use Include(x=>x.Difficulty)
            return await _context.Walks.Include("Difficulty").Include("Region").ToListAsync();
        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await _context.Walks
                .Include("Difficulty").Include("Region")
                .FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<Walk?> UpdateByIdAsync(Guid id, Walk walk)
        {
            Walk existingWalk = await _context.Walks
                .Include("Difficulty").Include("Region")
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existingWalk == null) { return null; }

            existingWalk.Name = walk.Name;
            existingWalk.Description = walk.Description;
            existingWalk.LengthInKm = walk.LengthInKm;
            existingWalk.WalkImageUrl = walk.WalkImageUrl;
            existingWalk.RegionId = walk.RegionId;
            existingWalk.DifficultyId = walk.DifficultyId;

            await _context.SaveChangesAsync();

            return existingWalk;

        }
        public async Task<Walk?> DeleteByIdAsync(Guid id)
        {
            Walk existingWalk = await _context.Walks
                .Include("Difficulty").Include("Region")
                .FirstOrDefaultAsync(x => x.Id == id);
            
            if (existingWalk == null) { return null; }

            _context.Walks.Remove(existingWalk);
            await _context.SaveChangesAsync();

            return existingWalk;
        }
    }
}
