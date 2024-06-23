using CosmicViewSharedLib.Models;
using CosmicViewSharedLib.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CosmicViewMvc.Controllers
{
    public class PicturesController : Controller
    {
        private readonly IPictureService _pictureService;

        public PicturesController(IPictureService pictureService)
        {
            _pictureService = pictureService;
        }

        public async Task<IActionResult> Index()
        {
            var pictures = await _pictureService.GetAllPicturesAsync();
            return View(pictures);
        }

        public async Task<IActionResult> Details(string date)
        {
            var picture = await _pictureService.GetPictureByDateAsync(date);
            if (picture == null)
            {
                return NotFound();
            }
            return View(picture);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Picture picture)
        {
            if (ModelState.IsValid)
            {
                await _pictureService.AddPictureAsync(picture);
                return RedirectToAction(nameof(Index));
            }
            return View(picture);
        }

        public async Task<IActionResult> Delete(string date)
        {
            var picture = await _pictureService.GetPictureByDateAsync(date);
            if (picture == null)
            {
                return NotFound();
            }
            return View(picture);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string date)
        {
            await _pictureService.DeletePictureByDateAsync(date);
            return RedirectToAction(nameof(Index));
        }
    }
}
