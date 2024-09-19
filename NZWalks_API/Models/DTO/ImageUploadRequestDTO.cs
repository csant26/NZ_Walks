using System.ComponentModel.DataAnnotations;

namespace NZWalks_API.Models.DTO
{
    public class ImageUploadRequestDTO
    {
        [Required]
        public IFormFile file {  get; set; }
        [Required]
        public string fileName { get; set; }
        public string? fileDescription {  get; set; }
    }
}
