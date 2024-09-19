using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks_API.Models.Domain;
using NZWalks_API.Models.DTO;
using NZWalks_API.Repository;

namespace NZWalks_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;

        public ImageController(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }
        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDTO imageUploadRequest)
        {
           ValidateFileUpload(imageUploadRequest);

            if (ModelState.IsValid)
            {
                //DTO to model
                var image = new Image
                {
                    file = imageUploadRequest.file,
                    fileExtension = Path.GetExtension(imageUploadRequest.file.FileName),
                    fileSizeInBytes = imageUploadRequest.file.FileName.Length,
                    fileName = imageUploadRequest.fileName,
                    fileDescription = imageUploadRequest.fileDescription,
                };

                //pass model to repository
                await _imageRepository.Upload(image);
                return Ok(image);

            }
            return BadRequest(ModelState);

        }
        private void ValidateFileUpload(ImageUploadRequestDTO imageUploadRequest)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png",".JPG" };
            
            if (!allowedExtensions.Contains(Path.GetExtension(imageUploadRequest.file.FileName)))
            {
                ModelState.AddModelError("file","Unsupported File Extension.");
            }
            if (imageUploadRequest.file.Length > 10485760)
            {
                ModelState.AddModelError("file", "File size more than 10 MB.");
            }
        }
    }
}
