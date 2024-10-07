using DotNetHttpClient.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetHttpClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClientService _httpClientService;
        public HomeController(HttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("/Products")]
        public async Task<JsonResult> Products()
        {
            var productsJson = await _httpClientService.GetProductData();
            return Json(productsJson);
        }
    }
}
