using NZWalks_API.Data;
using NZWalks_API.Models.Domain;

namespace NZWalks_API.Repository
{
    public class ImageRepository : IImageRepository
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly NZWalksDbContext _context;

        public ImageRepository(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor,
            NZWalksDbContext context)
        {
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }
        public async Task<Image> Upload(Image image)
        {
            var localFilePath = Path.Combine(_webHostEnvironment.ContentRootPath,
                "Images", $"{image.fileName}{image.fileExtension}");

            //Upload image to local path.
            using var stream = new FileStream(localFilePath, FileMode.Create);
            await image.file.CopyToAsync(stream);

            //URL path to access the image
            //https://localhost:1234/images/abc.jpg
            var urlFilePath = $"{_httpContextAccessor.HttpContext.Request.Scheme}://" +
                $"{_httpContextAccessor.HttpContext.Request.Host}" +
                $"{_httpContextAccessor.HttpContext.Request.PathBase}" +
                $"/Images/{image.fileName}{image.fileExtension}";

            image.filePath= urlFilePath;

            await _context.Images.AddAsync(image);
            await _context.SaveChangesAsync();


            return image;


        }
    }
}
