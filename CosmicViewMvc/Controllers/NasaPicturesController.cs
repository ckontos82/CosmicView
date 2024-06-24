using CosmicViewSharedLib.Models;
using CosmicViewSharedLib.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace CosmicViewMvc.Controllers
{
    public class NasaPicturesController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        public NasaPicturesController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
            _baseUrl = _httpClient.BaseAddress.ToString();
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Picture()
        {
            var fullUrl = $"{_baseUrl}/CosmicView";
            var pictureOfTheDay = await _httpClient.GetFromJsonAsync<List<Picture>>(fullUrl);
            return View(pictureOfTheDay);
        }

        [HttpGet]
        public async Task<IActionResult> FetchPictures(QueryParams queryParams)
        {
            var query = $"?Date={queryParams.Date}&StartDate={queryParams.StartDate}&EndDate={queryParams.EndDate}&Count={queryParams.Count}&Thumbs={queryParams.Thumbs}";

            var response = await _httpClient.GetFromJsonAsync<List<Picture>>($"{_baseUrl}/CosmicView{query}");

            if (response.Count > 0)
            {
                return View("Picture", response);
            }
            else
            {
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> SavePic(Picture picture)
        {
            var fullUrl = $"{_baseUrl}/CosmicView";

            if (ModelState.IsValid)
            {
                var response = await _httpClient.PostAsJsonAsync(fullUrl, picture);
                if (response.IsSuccessStatusCode)
                {
                    RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while saving the picture.");
                }
            }

            return RedirectToAction("Index", "Home");
        }

    }
}
