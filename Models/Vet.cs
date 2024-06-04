using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace pruebaDesempeno.Models
{
    public class Vet
    {
        public int Id { get; set; }
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
        [JsonIgnore]
        public ICollection<Quote>? Quotes { get; set; }
    }
}