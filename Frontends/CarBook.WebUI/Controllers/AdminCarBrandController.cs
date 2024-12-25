using CarBook.DTO.BrandDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class AdminCarBrandController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public AdminCarBrandController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// Tüm araç özelliklerini (Brand) listeleyen sayfayı getirir.
        /// </summary>
        /// <returns>Özelliklerin listesi ile View döner.</returns>
        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7003/api/Brands");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
                return View(data);
            }
            return View();
        }

        /// <summary>
        /// Yeni bir araç özelliği (Brand) oluşturma sayfasını getirir.
        /// </summary>
        /// <returns>Yeni özellik oluşturma görünümü döner.</returns>
        [HttpGet]
        public IActionResult CreateBrand()
        {
            return View();
        }

        /// <summary>
        /// Yeni bir araç özelliği (Brand) oluşturur.
        /// </summary>
        /// <param name="createBrandDto">Oluşturulacak özelliğin bilgilerini içeren DTO nesnesi.</param>
        /// <returns>
        /// Başarılıysa Index sayfasına yönlendirir.
        /// Başarısızsa mevcut görünümü döner.
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBrandDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7003/api/Brands", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        /// <summary>
        /// Belirli bir araç özelliğini (Brand) siler.
        /// </summary>
        /// <param name="id">Silinecek özelliğin benzersiz kimliği.</param>
        /// <returns>
        /// Başarılıysa Index sayfasına yönlendirir.
        /// Başarısızsa mevcut görünümü döner.
        /// </returns>
        public async Task<IActionResult> RemoveBrand(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7003/api/Brands/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        /// <summary>
        /// Belirli bir araç özelliğini (Brand) güncelleme sayfasını getirir.
        /// </summary>
        /// <param name="id">Güncellenecek özelliğin benzersiz kimliği.</param>
        /// <returns>
        /// Güncellenecek özelliğin bilgilerini içeren View döner.
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> UpdateBrand(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7003/api/Brands/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<UpdateBrandDto>(jsonData);
                return View(data);
            }
            return View();
        }

        /// <summary>
        /// Belirli bir araç özelliğini (Brand) günceller.
        /// </summary>
        /// <param name="updateBrandDto">Güncellenecek özelliğin bilgilerini içeren DTO nesnesi.</param>
        /// <returns>
        /// Güncelleme başarılıysa Index sayfasına yönlendirir.
        /// Güncelleme başarısız olursa mevcut görünümü döner.
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
        {
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBrandDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"https://localhost:7003/api/Brands/", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
