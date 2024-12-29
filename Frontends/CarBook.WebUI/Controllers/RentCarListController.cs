using CarBook.DTO.RentCarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class RentCarListController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public RentCarListController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index(int id)
        {
            var LocationId = TempData["locationID"];

            ViewBag.locationId = LocationId;

            id = int.Parse(LocationId.ToString());

            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7003/api/RentCars?LocationId={id}&Available=true");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<FilterRentCarDto>>(jsonData);
                return View(data);
            }
            return View();
        }
    }
}
