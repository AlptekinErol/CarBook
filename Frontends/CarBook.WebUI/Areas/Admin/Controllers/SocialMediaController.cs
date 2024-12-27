using CarBook.DTO.SocialMediaDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/SocialMedia")]
    public class SocialMediaController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public SocialMediaController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// Tüm SocialMedia'ları listeleyen sayfayı getirir.
        /// </summary>
        /// <returns>SocialMedia listesini içeren View döner.</returns>
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7003/api/SocialMedias");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(jsonData);
                return View(data);
            }
            return View();
        }

        /// <summary>
        /// Yeni bir SocialMedia oluşturma sayfasını getirir.
        /// </summary>
        /// <returns>Yeni SocialMedia oluşturma görünümü döner.</returns>
        [HttpGet]
        [Route("CreateSocialMedia")]
        public IActionResult CreateSocialMedia()
        {
            return View();
        }

        /// <summary>
        /// Yeni bir SocialMedia oluşturur.
        /// </summary>
        /// <param name="createSocialMediaDto">Oluşturulacak SocialMedia'ın bilgilerini içeren DTO nesnesi.</param>
        /// <returns>
        /// Başarılıysa Index sayfasına yönlendirir.
        /// Başarısızsa mevcut görünümü döner.
        /// </returns>
        [HttpPost]
        [Route("CreateSocialMedia")]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSocialMediaDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7003/api/SocialMedias", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "SocialMedia", new { area = "Admin" });
            }
            return View();
        }

        /// <summary>
        /// Belirli bir SocialMedia'ı siler.
        /// </summary>
        /// <param name="id">Silinecek SocialMedia'ın benzersiz kimliği.</param>
        /// <returns>
        /// Başarılıysa Index sayfasına yönlendirir.
        /// Başarısızsa mevcut görünümü döner.
        /// </returns>
        [Route("RemoveSocialMedia/{id}")]
        public async Task<IActionResult> RemoveSocialMedia(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7003/api/SocialMedias/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "SocialMedia", new { area = "Admin" });
            }
            return View();
        }

        /// <summary>
        /// Belirli bir SocialMedia'ın güncelleme sayfasını getirir.
        /// </summary>
        /// <param name="id">Güncellenecek SocialMedia'ın benzersiz kimliği.</param>
        /// <returns>
        /// Güncellenecek SocialMedia'ın bilgilerini içeren View döner.
        /// </returns>
        [HttpGet]
        [Route("UpdateSocialMedia/{id}")]
        public async Task<IActionResult> UpdateSocialMedia(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7003/api/SocialMedias/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<UpdateSocialMediaDto>(jsonData);
                return View(data);
            }
            return View();
        }

        /// <summary>
        /// Belirli bir SocialMedia'ı günceller.
        /// </summary>
        /// <param name="updateSocialMediaDto">Güncellenecek SocialMedia'ın bilgilerini içeren DTO nesnesi.</param>
        /// <returns>
        /// Güncelleme başarılıysa Index sayfasına yönlendirir.
        /// Güncelleme başarısız olursa mevcut görünümü döner.
        /// </returns>
        [HttpPost]
        [Route("UpdateSocialMedia/{id}")]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateSocialMediaDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"https://localhost:7003/api/SocialMedias/", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "SocialMedia", new { area = "Admin" });
            }
            return View();
        }
    }
}
