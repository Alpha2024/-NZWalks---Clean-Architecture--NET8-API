﻿using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Dtos
{
    public class UpdateWalksDto
    {


        [Required] public string Name { get; set; }
        [Required] public string Description { get; set; }
        [Required] public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        [Required] public Guid DifficultyId { get; set; }
        [Required] public Guid RegionId { get; set; }
        [Required] public bool IsActive { get; set; }
        [Required] public bool IsDeleted { get; set; }

    }
}
