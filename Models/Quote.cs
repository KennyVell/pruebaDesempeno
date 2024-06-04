using System.ComponentModel.DataAnnotations;

namespace pruebaDesempeno.Models
{
    public class Quote
    {
        public int Id { get; set; }
        [Required]
        public DateTime? Date { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public int? PetId { get; set; }
        public Pet? Pet { get; set; }
        [Required]
        public int? VetId { get; set; }
        public Vet? Vet { get; set; }
    }
}