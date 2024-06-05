using Microsoft.EntityFrameworkCore;
using pruebaDesempeno.Data;
using pruebaDesempeno.Models;
using pruebaDesempeno.DTOs;
using System.Net;

namespace pruebaDesempeno.Services.Quotes
{
    public class QuotesRepository : IQuotesRepository
    {
        private readonly VeterinaryContext _context;
        public QuotesRepository(VeterinaryContext context)
        {
            _context = context;
        }
        public async Task<(Quote quote, string message, HttpStatusCode statusCode)> Add(QuoteDTO quote)
        {
            if (quote.Description == null || quote.Date == null || !quote.PetId.HasValue || !quote.VetId.HasValue)
            {
                return (null, "All fields are required.", HttpStatusCode.BadRequest);
            }            
            var newQuote = new Quote
            {
                Description = quote.Description,
                Date = quote.Date,
                PetId = quote.PetId.Value,
                VetId = quote.VetId.Value
            };
            await _context.Quotes.AddAsync(newQuote);
            await _context.SaveChangesAsync();
            return (newQuote, "Quote created correctly", HttpStatusCode.Created);
        }

        public async Task<(IEnumerable<Quote> quotes, string message, HttpStatusCode statusCode)> GetAll()
        {
            var quotes = await _context.Quotes.Include(q => q.Vet).Include(q => q.Pet.Owner).ToListAsync();
            if (quotes.Any())
                return (quotes, "Quotes successfully obtained", HttpStatusCode.OK);
            else
                return (null, "Quotes not found!", HttpStatusCode.NotFound);
        }

        public async Task<(Quote quote, string message, HttpStatusCode statusCode)> GetById(int id)
        {
            var quote = await _context.Quotes.Include(q => q.Vet).Include(q => q.Pet.Owner).FirstOrDefaultAsync(p => p.Id == id);
            if (quote != null)
                return (quote, "Quote successfully obtained", HttpStatusCode.OK);
            else
                return (null, $"Quote not found with ID {id}!", HttpStatusCode.NotFound);
        }

        public async Task<(Quote quote, string message, HttpStatusCode statusCode)> Update(int id, QuoteDTO quoteUpdate)
        {
            var quote = await _context.Quotes.FindAsync(id);
            if (quote == null)
            {
                return (null, "Quote not found!", HttpStatusCode.NotFound);
            }

            // Update required fields only if not null
            if (!string.IsNullOrEmpty(quoteUpdate.Description))
            {
                quote.Description = quoteUpdate.Description;
            }
            if (quoteUpdate.Date != null)
            {
                quote.Date = quoteUpdate.Date;
            }
            if (quoteUpdate.PetId.HasValue && quoteUpdate.PetId != 0)
            {
                quote.PetId = quoteUpdate.PetId.Value;
            }
            if (quoteUpdate.VetId.HasValue && quoteUpdate.VetId != 0)
            {
                quote.VetId = quoteUpdate.VetId.Value;
            }

            _context.Entry(quote).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return (quote, "Quote updated correctly", HttpStatusCode.OK);
        }
    }
}