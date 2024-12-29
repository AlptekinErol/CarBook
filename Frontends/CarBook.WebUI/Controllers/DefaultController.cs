using CarBook.DTO.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7003/api/Locations");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
            List<SelectListItem> dataList = (from x in values
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.LocationId.ToString()
                                             }).ToList();
            ViewBag.v = dataList;
            return View();
        }

        [HttpPost]
        public IActionResult Index(string pick_date, string off_date, string time_pick, string time_off, string locationId)
        {
            TempData["pickdate"] = pick_date;
            TempData["offdate"] = off_date;
            TempData["timepick"] = time_pick;
            TempData["timeoff"] = time_off;
            TempData["locationID"] = locationId;
            return RedirectToAction("Index", "RentCarList");
        }
    }
}
