using System.Collections.Concurrent;
using UrlShortener.Domain.Models;

namespace UrlShortener.Infrastructure.Repositories
{
    public class InMemoryUrlRepository
    {
        private ConcurrentDictionary<string, ShortUrl> _storage;

        public InMemoryUrlRepository()
        {
            _storage = new ConcurrentDictionary<string, ShortUrl>();
        }

        public bool Exists(string code)
        {
            if (_storage.ContainsKey(code))
            {
                return true;
            }

            return false;
        }

        public void Add(ShortUrl shortUrl)
        {
            _storage[shortUrl.Code] = shortUrl;
        }

        public ShortUrl? Get(string code)
        {
            ShortUrl? value;

            bool found = _storage.TryGetValue(code, out value);

            if (found)
            {
                return value;
            }

            return null;
        }
    }
}
