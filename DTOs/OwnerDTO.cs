using System.ComponentModel.DataAnnotations;

namespace pruebaDesempeno.DTOs
{
    public class OwnerDTO
    {
        [Required]
        public string? Names { get; set; }
        [Required]
        public string? LastNames { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? Phone { get; set; }
    }
}