using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NZWalks.Web.Core.Enums;
using NZWalks.Web.Core.ExternalEndpoint;
using NZWalks.Web.Core.Models.Dtos;

namespace NZWalks.Web.Controllers
{

    public class RegionsController : Controller
    {

        private readonly IHttpService _httpClient;
        public RegionsController(IHttpService httpClient)
        {

            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var regions = new List<RegionsDto>();
            try
            {
                var regionsResponse = await _httpClient.MakeApiRequest(HttpVerb.GET, "api/Region/Retrive_all_Regions");
                regionsResponse.EnsureSuccessStatusCode();

                regions.AddRange(await regionsResponse.Content.ReadFromJsonAsync<IEnumerable<RegionsDto>>());
            }
            catch (Exception)
            {
                throw;
            }
            return View(regions);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddRegionViewModel addRegionViewModel)
        {
            try
            {
                var Httpresponse = await _httpClient.MakeApiRequest(HttpVerb.POST, "api/Region/EnterRegion", JsonConvert.SerializeObject(addRegionViewModel));
                Httpresponse.EnsureSuccessStatusCode();

                if (!Httpresponse.IsSuccessStatusCode)
                {
                    var errorContent = await Httpresponse.Content.ReadAsStringAsync();
                    Console.WriteLine("API Error Response: " + errorContent); // or log it
                    return View("Error"); // or your fallback logic
                }

                var content = await Httpresponse.Content.ReadFromJsonAsync<RegionsDto>();
                if (content is not null)
                {
                    return RedirectToAction("Index", "Regions");
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var httpResponse = await _httpClient.MakeApiRequest(HttpVerb.GET, $"api/Region/region/{id}");

            if (httpResponse != null && httpResponse.IsSuccessStatusCode)
            {
                var content = await httpResponse.Content.ReadAsStringAsync();

                var region = JsonConvert.DeserializeObject<RegionsDto>(content);

                return View(region);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RegionsDto regionsDto)
        {
            try
            {
                var httpResponseMessage = await _httpClient.MakeApiRequest(HttpVerb.PUT, $"api/Region/updateRegion/{regionsDto.Id}", JsonConvert.SerializeObject(regionsDto));
                httpResponseMessage.EnsureSuccessStatusCode();
                var content = await httpResponseMessage.Content.ReadFromJsonAsync<RegionsDto>();
                if (content is not null)
                {
                    return RedirectToAction("Index", "Regions");
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error", ex);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var httpResponse = await _httpClient.MakeApiRequest(HttpVerb.GET, $"api/Region/region/{id}");

                // Ensure response is successful
                if (httpResponse != null && httpResponse.IsSuccessStatusCode)
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();

                    // Deserialize the JSON content into RegionsDto
                    var region = JsonConvert.DeserializeObject<RegionsDto>(content);

                    return View(region); // Pass model to view
                }
            }
            catch (Exception)
            {
                throw;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(RegionsDto regionsDto)
        {
            try
            {
                var httpreponseMessage = await _httpClient.MakeApiRequest(HttpVerb.DELETE, $"api/Region/Delete_Region/{regionsDto.Id}");
                httpreponseMessage.EnsureSuccessStatusCode();
                return RedirectToAction("Index", "Regions");
            }
            catch (Exception)
            {
                //log console
            }
            return View();
        }
    }
}
