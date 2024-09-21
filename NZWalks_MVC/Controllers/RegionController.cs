using Microsoft.AspNetCore.Mvc;
using NZWalks_MVC.Models;
using NZWalks_MVC.Models.DTO;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace NZWalks_MVC.Controllers
{
    public class RegionController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string url = "https://localhost:7218/api/Region";
        public RegionController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<RegionDTO> response = new List<RegionDTO>();
            try
            {
                var client = _httpClientFactory.CreateClient();
                var httpResponse = await client.GetAsync(url);

                httpResponse.EnsureSuccessStatusCode();

                response.AddRange(await httpResponse.Content.ReadFromJsonAsync<IEnumerable<RegionDTO>>());


            }
            catch (Exception ex)
            {

                throw;
            }

            return View(response);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddRegionViewModel addRegion)
        {
            var client = _httpClientFactory.CreateClient();
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(url),
                Content = new StringContent(JsonSerializer.Serialize(addRegion),Encoding.UTF8,"application/json")
            };
            var httpResponseMessage = await client.SendAsync(httpRequestMessage);

            httpResponseMessage.EnsureSuccessStatusCode();

            var response = httpResponseMessage.Content.ReadFromJsonAsync<RegionDTO>();

            if (response is not null)
            {
                return RedirectToAction("Index", "Region");
            }

            return View();

        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetFromJsonAsync <RegionDTO> (url+$"/{id.ToString()}");
            if(response is not null)
            {
                return View(response);
            }
            
            return View(null);
        }
       
        [HttpPost]
        public async Task<IActionResult> Edit(RegionDTO regionDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"{url}/{regionDTO.Id.ToString()}"),
                Content = new StringContent(JsonSerializer.Serialize(regionDTO), Encoding.UTF8, "application/json")
            };

            var httpResponseMessage = await client.SendAsync(httpRequestMessage);
            httpResponseMessage.EnsureSuccessStatusCode();
            var response = await httpResponseMessage.Content.ReadFromJsonAsync<RegionDTO>();

            if (response is not null)
            {
                return RedirectToAction("Edit", "Region");
            }

            return View();


        }


    }
}   
