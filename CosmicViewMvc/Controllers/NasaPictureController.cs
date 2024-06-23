using CosmicViewSharedLib.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CosmicViewMvc.Controllers
{
    public class NasaPicturesController : Controller
    {
        private readonly IPictureService _pictureService;

        public NasaPicturesController(IPictureService pictureService)
        {
            _pictureService = pictureService;
        }


    }
}
