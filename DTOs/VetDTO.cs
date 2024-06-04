using System.ComponentModel.DataAnnotations;

namespace pruebaDesempeno.DTOs
{
    public class VetDTO
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Phone { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public int? ExperienceYears { get; set; }
    }
}