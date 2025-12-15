using System.Text;
using UrlShortener.Application.Interfaces;
using UrlShortener.Domain.Models;
using UrlShortener.Infrastructure.Repositories;

namespace UrlShortener.Application.Services
{
    public class UrlService : IUrlService
    {
        private readonly InMemoryUrlRepository _repository;
        private static readonly SemaphoreSlim _semaphore = new(1, 1);

        public UrlService(InMemoryUrlRepository repository)
        {
            _repository = repository;
        }

        public async Task<ShortUrl> CreateAsync(string originalUrl, string? alias)
        {
            await _semaphore.WaitAsync();
            try
            {
                var code = string.IsNullOrWhiteSpace(alias)
                              ? GenerateCode()
                              : alias;

                if (_repository.Exists(code))
                    throw new InvalidOperationException("Alias está em uso!");

                var shortUrl = new ShortUrl
                {
                    Code = code,
                    OriginalUrl = originalUrl
                };

                _repository.Add(shortUrl);
                return shortUrl;
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public Task<ShortUrl?> GetByCodeAsync(string code)
        {
            return Task.FromResult(_repository.Get(code));
        }

        private string GenerateCode()
        {
            return Convert.ToBase64String(Guid.NewGuid().ToByteArray())
                .Replace("/", "")
                .Replace("+", "")
                .Substring(0, 6);
        }
    }
}
