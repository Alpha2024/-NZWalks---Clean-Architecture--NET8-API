

using System.ComponentModel.DataAnnotations;

namespace NZwalks.Core.Domain.Entities
{
    public class BaseClass
    {
        [Key]
        public Guid Id { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
