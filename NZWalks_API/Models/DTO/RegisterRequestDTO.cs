using System.ComponentModel.DataAnnotations;

namespace NZWalks_API.Models.DTO
{
    public class RegisterRequestDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string userName {  get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        public string[] roles { get; set; }
    }
}
