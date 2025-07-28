using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Dtos
{
    public class AddWalksDto
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Walks name should have a maximum of 100 character long")]
        public string Name { get; set; }
        [Required]
        [MaxLength(1000, ErrorMessage = "Walks name should have a maximum of 1000 character long")]
        public string Description { get; set; }
        [Required]
        [Range(0, 50)]
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        [Required]
        public Guid DifficultyId { get; set; }
        [Required]
        public Guid RegionId { get; set; }
    }
}
