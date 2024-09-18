using System.ComponentModel.DataAnnotations;

namespace NZWalks_API.Models.DTO
{
    public class UpdateWalkRequestDTO
    {
        [Required]
        [MinLength(3, ErrorMessage = "Name has to be min of 3 letters.")]
        [MaxLength(100, ErrorMessage = "Name has to be max of 100 letters.")]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        [Required]
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        [Required]
        public Guid DifficultyId { get; set; }
        [Required]
        public Guid RegionId { get; set; }
    }
}
