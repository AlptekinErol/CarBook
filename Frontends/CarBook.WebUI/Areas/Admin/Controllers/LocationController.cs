using CarBook.DTO.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Location")]
    public class LocationController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public LocationController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// Tüm Location'ları listeleyen sayfayı getirir.
        /// </summary>
        /// <returns>Location listesini içeren View döner.</returns>
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7003/api/Locations");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
                return View(data);
            }
            return View();
        }

        /// <summary>
        /// Yeni bir Location oluşturma sayfasını getirir.
        /// </summary>
        /// <returns>Yeni Location oluşturma görünümü döner.</returns>
        [HttpGet]
        [Route("CreateLocation")]
        public IActionResult CreateLocation()
        {
            return View();
        }

        /// <summary>
        /// Yeni bir Location oluşturur.
        /// </summary>
        /// <param name="createLocationDto">Oluşturulacak Location'ın bilgilerini içeren DTO nesnesi.</param>
        /// <returns>
        /// Başarılıysa Index sayfasına yönlendirir.
        /// Başarısızsa mevcut görünümü döner.
        /// </returns>
        [HttpPost]
        [Route("CreateLocation")]
        public async Task<IActionResult> CreateLocation(CreateLocationDto createLocationDto)
        {
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createLocationDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7003/api/Locations", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Location", new { area = "Admin" });
            }
            return View();
        }

        /// <summary>
        /// Belirli bir Location'ı siler.
        /// </summary>
        /// <param name="id">Silinecek Location'ın benzersiz kimliği.</param>
        /// <returns>
        /// Başarılıysa Index sayfasına yönlendirir.
        /// Başarısızsa mevcut görünümü döner.
        /// </returns>
        [Route("RemoveLocation/{id}")]
        public async Task<IActionResult> RemoveLocation(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7003/api/Locations/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Location", new { area = "Admin" });
            }
            return View();
        }

        /// <summary>
        /// Belirli bir Location'ın güncelleme sayfasını getirir.
        /// </summary>
        /// <param name="id">Güncellenecek Location'ın benzersiz kimliği.</param>
        /// <returns>
        /// Güncellenecek Location'ın bilgilerini içeren View döner.
        /// </returns>
        [HttpGet]
        [Route("UpdateLocation/{id}")]
        public async Task<IActionResult> UpdateLocation(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7003/api/Locations/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<UpdateLocationDto>(jsonData);
                return View(data);
            }
            return View();
        }

        /// <summary>
        /// Belirli bir Location'ı günceller.
        /// </summary>
        /// <param name="updateLocationDto">Güncellenecek Location'ın bilgilerini içeren DTO nesnesi.</param>
        /// <returns>
        /// Güncelleme başarılıysa Index sayfasına yönlendirir.
        /// Güncelleme başarısız olursa mevcut görünümü döner.
        /// </returns>
        [HttpPost]
        [Route("UpdateLocation/{id}")]
        public async Task<IActionResult> UpdateLocation(UpdateLocationDto updateLocationDto)
        {
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateLocationDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"https://localhost:7003/api/Locations/", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Location", new { area = "Admin" });
            }
            return View();
        }
    }
}
