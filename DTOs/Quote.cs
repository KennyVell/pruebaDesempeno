using System.ComponentModel.DataAnnotations;

namespace pruebaDesempeno.DTOs
{
    public class QuoteDTO
    {
        [Required]
        public DateTime? Date { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public int? PetId { get; set; }
        [Required]
        public int? VetId { get; set; }
    }
}