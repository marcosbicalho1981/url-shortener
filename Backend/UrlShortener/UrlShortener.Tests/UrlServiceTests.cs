using UrlShortener.Application.Services;
using UrlShortener.Infrastructure.Repositories;

namespace UrlShortener.Tests
{
    public class UrlServiceTests
    {
        [Fact]
        public async Task CreateAsync_ShouldCreateShortUrl_WhenAliasIsNotProvided()
        {
            // Arrange
            var repository = new InMemoryUrlRepository();
            var service = new UrlService(repository);

            var originalUrl = "https://www.topazevolution.com/";

            // Act
            var result = await service.CreateAsync(originalUrl, null);

            // Assert
            Assert.NotNull(result);
            Assert.False(string.IsNullOrEmpty(result.Code));
            Assert.Equal(originalUrl, result.OriginalUrl);
        }

        [Fact]
        public async Task CreateAsync_ShouldThrowException_WhenAliasAlreadyExists()
        {
            // Arrange
            var repository = new InMemoryUrlRepository();
            var service = new UrlService(repository);

            var originalUrl1 = "https://www.topazevolution.com/";
            var originalUrl2 = "https://www.github.com";
            var alias = "meulink";

            // Act
            await service.CreateAsync(originalUrl1, alias);

            // Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await service.CreateAsync(originalUrl2, alias);
            });
        }

    }
}
