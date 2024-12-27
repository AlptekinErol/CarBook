using CarBook.DTO.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Service")]
    public class ServiceController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public ServiceController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// Tüm Service'ları listeleyen sayfayı getirir.
        /// </summary>
        /// <returns>Service listesini içeren View döner.</returns>
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7003/api/Services");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
                return View(data);
            }
            return View();
        }

        /// <summary>
        /// Yeni bir Service oluşturma sayfasını getirir.
        /// </summary>
        /// <returns>Yeni Service oluşturma görünümü döner.</returns>
        [HttpGet]
        [Route("CreateService")]
        public IActionResult CreateService()
        {
            return View();
        }

        /// <summary>
        /// Yeni bir Service oluşturur.
        /// </summary>
        /// <param name="createServiceDto">Oluşturulacak Service'ın bilgilerini içeren DTO nesnesi.</param>
        /// <returns>
        /// Başarılıysa Index sayfasına yönlendirir.
        /// Başarısızsa mevcut görünümü döner.
        /// </returns>
        [HttpPost]
        [Route("CreateService")]
        public async Task<IActionResult> CreateService(CreateServiceDto createServiceDto)
        {
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createServiceDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7003/api/Services", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Service", new { area = "Admin" });
            }
            return View();
        }

        /// <summary>
        /// Belirli bir Service'ı siler.
        /// </summary>
        /// <param name="id">Silinecek Service'ın benzersiz kimliği.</param>
        /// <returns>
        /// Başarılıysa Index sayfasına yönlendirir.
        /// Başarısızsa mevcut görünümü döner.
        /// </returns>
        [Route("RemoveService/{id}")]
        public async Task<IActionResult> RemoveService(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7003/api/Services/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Service", new { area = "Admin" });
            }
            return View();
        }

        /// <summary>
        /// Belirli bir Service'ın güncelleme sayfasını getirir.
        /// </summary>
        /// <param name="id">Güncellenecek Service'ın benzersiz kimliği.</param>
        /// <returns>
        /// Güncellenecek Service'ın bilgilerini içeren View döner.
        /// </returns>
        [HttpGet]
        [Route("UpdateService/{id}")]
        public async Task<IActionResult> UpdateService(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7003/api/Services/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<UpdateServiceDto>(jsonData);
                return View(data);
            }
            return View();
        }

        /// <summary>
        /// Belirli bir Service'ı günceller.
        /// </summary>
        /// <param name="updateServiceDto">Güncellenecek Service'ın bilgilerini içeren DTO nesnesi.</param>
        /// <returns>
        /// Güncelleme başarılıysa Index sayfasına yönlendirir.
        /// Güncelleme başarısız olursa mevcut görünümü döner.
        /// </returns>
        [HttpPost]
        [Route("UpdateService/{id}")]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
        {
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateServiceDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"https://localhost:7003/api/Services/", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Service", new { area = "Admin" });
            }
            return View();
        }
    }
}
