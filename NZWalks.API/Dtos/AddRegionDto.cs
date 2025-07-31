using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Dtos
{
    public class AddRegionDto
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Name has to be a maximum of 100 characters")]
        public string Name { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Code must be a minimum of 3 characters")]
        [MaxLength(3, ErrorMessage = "Code must be a maximum of 3 characters")]
        public string Code { get; set; }

        public string? RegionImageUrl { get; set; }
    }

}
