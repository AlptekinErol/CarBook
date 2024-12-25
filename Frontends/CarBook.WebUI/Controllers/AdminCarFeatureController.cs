using CarBook.DTO.CarDtos;
using CarBook.DTO.FeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    /// <summary>
    /// Araç özellikleri (Feature) yönetimini gerçekleştiren Controller sınıfı.
    /// </summary>
    public class AdminCarFeatureController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public AdminCarFeatureController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// Tüm araç özelliklerini (Feature) listeleyen sayfayı getirir.
        /// </summary>
        /// <returns>Özelliklerin listesi ile View döner.</returns>
        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7003/api/Features");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
                return View(data);
            }
            return View();
        }

        /// <summary>
        /// Yeni bir araç özelliği (Feature) oluşturma sayfasını getirir.
        /// </summary>
        /// <returns>Yeni özellik oluşturma görünümü döner.</returns>
        [HttpGet]
        public IActionResult CreateFeature()
        {
            return View();
        }

        /// <summary>
        /// Yeni bir araç özelliği (Feature) oluşturur.
        /// </summary>
        /// <param name="createFeatureDto">Oluşturulacak özelliğin bilgilerini içeren DTO nesnesi.</param>
        /// <returns>
        /// Başarılıysa Index sayfasına yönlendirir.
        /// Başarısızsa mevcut görünümü döner.
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createFeatureDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7003/api/Features", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        /// <summary>
        /// Belirli bir araç özelliğini (Feature) siler.
        /// </summary>
        /// <param name="id">Silinecek özelliğin benzersiz kimliği.</param>
        /// <returns>
        /// Başarılıysa Index sayfasına yönlendirir.
        /// Başarısızsa mevcut görünümü döner.
        /// </returns>
        public async Task<IActionResult> RemoveFeature(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7003/api/Features/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        /// <summary>
        /// Belirli bir araç özelliğini (Feature) güncelleme sayfasını getirir.
        /// </summary>
        /// <param name="id">Güncellenecek özelliğin benzersiz kimliği.</param>
        /// <returns>
        /// Güncellenecek özelliğin bilgilerini içeren View döner.
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> UpdateFeature(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7003/api/Features/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<UpdateFeatureDto>(jsonData);
                return View(data);
            }
            return View();
        }

        /// <summary>
        /// Belirli bir araç özelliğini (Feature) günceller.
        /// </summary>
        /// <param name="updateFeatureDto">Güncellenecek özelliğin bilgilerini içeren DTO nesnesi.</param>
        /// <returns>
        /// Güncelleme başarılıysa Index sayfasına yönlendirir.
        /// Güncelleme başarısız olursa mevcut görünümü döner.
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateFeatureDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"https://localhost:7003/api/Features/", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
