using NZWalks_API.Models.Domain;
using NZWalks_API.Models.DTO;

namespace NZWalks_API.Repository
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();
        Task<Region?> GetByIdAsync(Guid id);
        Task<Region> CreateRegionAsync(Region region);
        Task<Region?> UpdateRegionAsync(Guid id,Region updatedRegion);
        Task<Region?> DeleteByIdAsync(Guid id);

    }
}
