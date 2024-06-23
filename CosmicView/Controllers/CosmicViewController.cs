using CosmicView.Models;
using CosmicView.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CosmicView.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class CosmicViewController : ControllerBase
    {
        private readonly ICosmicViewApiService _apiService;
        private readonly IPictureService _pictureService;

        public CosmicViewController(ICosmicViewApiService apiService, IPictureService pictureService)
        {
            _apiService = apiService;
            _pictureService = pictureService;
        }

        [HttpGet]
        public async Task<IActionResult> GetApod([FromQuery] QueryParams queryParams)
        { 
            var apods = await _apiService.GetPictureAsync(queryParams);
            return Ok(apods);
        }

        [HttpPost]
        public async Task<IActionResult> PostPicture([FromBody]Picture picture)
        {
            await _pictureService.AddPictureAsync(picture);
            return Ok();
        }
    }
}
