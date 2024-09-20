using Microsoft.AspNetCore.Mvc;
using NZWalks_MVC.Models.DTO;

namespace NZWalks_MVC.Controllers
{
    public class RegionController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RegionController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            List<RegionDTO> response = new List<RegionDTO>();
            try
            {
                var client = _httpClientFactory.CreateClient();
                var httpResponse = await client.GetAsync("https://localhost:7218/api/Region");

                httpResponse.EnsureSuccessStatusCode();

                response.AddRange(await httpResponse.Content.ReadFromJsonAsync<IEnumerable<RegionDTO>>());


            }
            catch (Exception ex)
            {

                throw;
            }

            return View(response);
        }
    }
}
