using Microsoft.EntityFrameworkCore;
using pruebaDesempeno.Models;

namespace pruebaDesempeno.Data
{
    public class VeterinaryContext : DbContext
    {
        public VeterinaryContext(DbContextOptions<VeterinaryContext> options) : base(options) { }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Vet> Vets { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Quote> Quotes { get; set; }

    }
}