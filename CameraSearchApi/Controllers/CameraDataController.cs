using System.Collections.Generic;
using CameraSearchService.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace CameraSearchApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CameraDataController : ControllerBase
    {
        private readonly IMemoryCache _cache;
        public CameraDataController(IMemoryCache cache)
        {
            _cache = cache;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CameraData>> Get()
        {
            //TODO: Add check if not in cache retrieve from file / update cache
            var cacheEntry =  _cache.Get<IEnumerable<CameraData>>("camera");
            
            return Ok(cacheEntry);
        }
    }
}
