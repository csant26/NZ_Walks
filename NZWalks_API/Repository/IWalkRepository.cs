using NZWalks_API.Models.Domain;

namespace NZWalks_API.Repository
{
    public interface IWalkRepository
    {
        Task<Walk> CreateAsync(Walk walk);
        Task<List<Walk>> GetAllAsync();
        Task<Walk?> GetByIdAsync(Guid id);
        Task<Walk?> UpdateByIdAsync(Guid id, Walk walk);
        Task<Walk?> DeleteByIdAsync(Guid id);   
    }
}
