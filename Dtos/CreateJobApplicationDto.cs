using System.ComponentModel.DataAnnotations;

namespace JobApplicationTracker.Api.Dtos
{
    public class CreateJobApplicationDto
    {
        [Required]
        [StringLength(50)]
        public string Company { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Position { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string? Notes { get; set; } = string.Empty;
    }
}
