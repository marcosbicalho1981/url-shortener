using UrlShortener.Domain.Models;

namespace UrlShortener.Application.Interfaces
{
    public interface IUrlService
    {
        Task<ShortUrl> CreateAsync(string originalUrl, string? alias);
        Task<ShortUrl?> GetByCodeAsync(string code);
    }
}
