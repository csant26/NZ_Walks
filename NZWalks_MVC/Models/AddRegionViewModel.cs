using System.ComponentModel.DataAnnotations;

namespace NZWalks_MVC.Models
{
    public class AddRegionViewModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
