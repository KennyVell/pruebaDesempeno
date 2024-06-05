using System.Net;
using pruebaDesempeno.DTOs;
using pruebaDesempeno.Models;

namespace pruebaDesempeno.Services.Quotes
{
    public interface IQuotesRepository
    {
        Task<(Quote quote, string message, HttpStatusCode statusCode)> Add(QuoteDTO quote);  
        Task<(IEnumerable<Quote> quotes, string message, HttpStatusCode statusCode)> GetAll();
        Task<(Quote quote, string message, HttpStatusCode statusCode)> GetById(int id);
        Task<(IEnumerable<Quote> quotes, string message, HttpStatusCode statusCode)> GetByVetId(int id);
        Task<(IEnumerable<Quote> quotes, string message, HttpStatusCode statusCode)> GetByDate(DateTime date);
        Task<(Quote quote, string message, HttpStatusCode statusCode)> Update(int id, QuoteDTO quoteUpdate);
    }
}