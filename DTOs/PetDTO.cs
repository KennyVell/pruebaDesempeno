using System.ComponentModel.DataAnnotations;

namespace pruebaDesempeno.DTOs 
{
    public class PetDTO
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Specie { get; set; }
        [Required]
        public string? Race { get; set; }
        [Required]
        public DateTime? DateBirth { get; set; }
        [Required]
        public string? Photo { get; set; }
        [Required]
        public int? OwnerId { get; set; }

    }
}