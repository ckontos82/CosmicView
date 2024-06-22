using CosmicView.Models;
using CosmicView.Services;
using Microsoft.AspNetCore.Mvc;

namespace CosmicView.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class CosmicViewController : ControllerBase
    {
        private readonly CosmicViewApiService _apiService;

        public CosmicViewController(CosmicViewApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        public async Task<IActionResult> GetApod([FromQuery] QueryParams queryParams)
        { 
            var apods = await _apiService.GetPictureAsync(queryParams);
            return Ok(apods);
        }
    }
}
