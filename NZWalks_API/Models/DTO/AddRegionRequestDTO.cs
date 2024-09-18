using System.ComponentModel.DataAnnotations;

namespace NZWalks_API.Models.DTO
{
    public class AddRegionRequestDTO
    {
        [Required]
        [MinLength(3,ErrorMessage ="Code has to be of minimum 3 letters.")]
        [MaxLength(3,ErrorMessage ="Code can be of maximum 3 letters. ")]
        public string Code { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Name has to be of minimum 3 letters.")]
        [MaxLength(3, ErrorMessage = "Name can be of maximum 100 letters. ")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
