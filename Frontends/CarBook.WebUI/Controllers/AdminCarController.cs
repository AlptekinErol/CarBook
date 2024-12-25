using CarBook.DTO.BrandDtos;
using CarBook.DTO.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    /// <summary>
    /// Araç yönetimi işlemlerini gerçekleştiren Admin Controller sınıfı.
    /// </summary>
    public class AdminCarController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        /// <summary>
        /// AdminCarController için yapılandırıcı metod.
        /// </summary>
        /// <param name="httpClientFactory">HTTP istemcilerini oluşturmak için kullanılan IHttpClientFactory nesnesi.</param>
        public AdminCarController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// Tüm araçları listeleyen sayfayı döner.
        /// </summary>
        /// <returns>Araçların listesi ile View döner.</returns>
        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7003/api/Cars/GetCarWithBrand");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<ResultCarWithBrandDto>>(jsonData);
                return View(data);
            }
            return View();
        }

        /// <summary>
        /// Yeni araç ekleme sayfasını getirir.
        /// </summary>
        /// <returns>Marka bilgilerini içeren View döner.</returns>
        [HttpGet]
        public async Task<IActionResult> CreateCar()
        {
            ViewBag.BrandValues = await GetBrandSelectListAsync();
            return View();
        }

        /// <summary>
        /// Yeni araç bilgilerini API'ye göndererek araç ekler.
        /// </summary>
        /// <param name="createCarDto">Eklenecek aracın bilgilerini içeren DTO nesnesi.</param>
        /// <returns>Başarılı ise Index sayfasına yönlendirir.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarDto createCarDto)
        {
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCarDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7003/api/Cars", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        /// <summary>
        /// Belirli bir aracı siler.
        /// </summary>
        /// <param name="id">Silinecek aracın benzersiz kimliği.</param>
        /// <returns>Başarılı ise Index sayfasına yönlendirir.</returns>
        public async Task<IActionResult> RemoveCar(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7003/api/Cars/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        /// <summary>
        /// Belirli bir aracın güncelleme sayfasını getirir.
        /// </summary>
        /// <param name="id">Güncellenecek aracın benzersiz kimliği.</param>
        /// <returns>Araç bilgilerini içeren View döner.</returns>
        [HttpGet]
        public async Task<IActionResult> UpdateCar(int id)
        {
            var client = httpClientFactory.CreateClient();
            ViewBag.BrandValues = await GetBrandSelectListAsync();
            var responseMessage = await client.GetAsync($"https://localhost:7003/api/Cars/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<UpdateCarDto>(jsonData);
                return View(data);
            }
            return View();
        }

        /// <summary>
        /// Belirli bir aracın bilgilerini günceller.
        /// </summary>
        /// <param name="updateCarDto">
        /// Güncellenecek aracın bilgilerini içeren DTO nesnesi.
        /// </param>
        /// <returns>
        /// Güncelleme başarılıysa Index sayfasına yönlendirir.
        /// Güncelleme başarısız olursa mevcut görünümü döner.
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> UpdateCar(UpdateCarDto updateCarDto)
        {
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCarDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"https://localhost:7003/api/Cars/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        /// <summary>
        /// API'den marka verilerini alır ve bir SelectListItem listesi oluşturur.
        /// </summary>
        /// <returns>
        /// Marka verilerini içeren bir <see cref="List{SelectListItem}"/> nesnesi döner.
        /// </returns>
        private async Task<List<SelectListItem>> GetBrandSelectListAsync()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7003/api/Brands");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);

                return (from x in data
                        select new SelectListItem
                        {
                            Text = x.Name,
                            Value = x.BrandId.ToString()
                        }).ToList();
            }
            return new List<SelectListItem>();
        }
    }
}
