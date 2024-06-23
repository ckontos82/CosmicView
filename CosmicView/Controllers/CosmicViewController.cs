using CosmicView.Models;
using CosmicView.Services.Interfaces;
using CosmicViewSharedLib.Models;
using CosmicViewSharedLib.Services.Interfaces;
using Microsoft.AspNetCore.Http;
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

        [HttpGet("{date}")]
        public async Task<IActionResult> GetPictureByDate(string date)
        {
            var picture = await _pictureService.GetPictureByDateAsync(date);
            if (picture is null) return NotFound();

            return Ok(picture);
        }

        [HttpGet("pictures")]
        public async Task<IActionResult> GetPicturesFromDb()
        {
            var pictures = await _pictureService.GetAllPicturesAsync();
            return Ok(pictures);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> PostPicture([FromBody] Picture picture)
        {
            try
            {
                await _pictureService.AddPictureAsync(picture);
                return Created("", picture);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }

        [HttpDelete("{date}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeletePicture(string date)
        {
            var success = await _pictureService.DeletePictureByDateAsync(date);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
