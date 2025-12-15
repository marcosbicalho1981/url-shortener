using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Application.Interfaces;

namespace UrlShortener.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly IUrlService _service;

        public UrlController(IUrlService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUrlRequest request)
        {
            var result = await _service.CreateAsync(request.OriginalUrl, request.Alias);
            return Ok(result);
        }

        [HttpGet("/{code}")]
        public async Task<IActionResult> RedirectToOriginal(string code)
        {
            var url = await _service.GetByCodeAsync(code);
            if (url == null) return NotFound();

            return Redirect(url.OriginalUrl);
        }

    }

    public class CreateUrlRequest
    {
        public string OriginalUrl { get; set; } = string.Empty;
        public string? Alias { get; set; }
    }

}
