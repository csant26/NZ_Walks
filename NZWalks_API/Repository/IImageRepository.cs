using NZWalks_API.Models.Domain;

namespace NZWalks_API.Repository
{
    public interface IImageRepository
    {
        Task<Image> Upload(Image image);
    }
}
