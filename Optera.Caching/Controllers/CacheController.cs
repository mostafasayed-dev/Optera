using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace Optera.Caching.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public class CacheController : Controller
    {
        private readonly IDistributedCache _cache;
        public CacheController(IDistributedCache cache)
        {
            _cache = cache;
        }

        [HttpGet("{key}")]
        public async Task<IActionResult> Get(string key)
        {
            var value = await _cache.GetStringAsync(key);
            if (value == null) return NotFound();
            return Ok(value);
        }

        [HttpPost("{key}")]
        public async Task<IActionResult> Set(string key, [FromBody] CacheItemDto cacheItemDto)
        {
            await _cache.SetStringAsync(key, cacheItemDto.Value, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
            });
            return Ok();
        }
    }

    public class CacheItemDto
    {
        public string Value { get; set; }
    }
}
