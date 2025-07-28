using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Dtos
{
    public class AddRegionDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Code has be a minimum of 3 charracters")]
        [MaxLength(3, ErrorMessage = "Code has be a maximum of 3 charracters")]
        public string Name { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Name has be a maximum of 100 charracters")]
        public string Code { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
