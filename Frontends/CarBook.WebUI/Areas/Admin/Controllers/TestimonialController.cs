using CarBook.DTO.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Testimonial")]
    public class TestimonialController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public TestimonialController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// Tüm Testimonial'ları listeleyen sayfayı getirir.
        /// </summary>
        /// <returns>Testimonial listesini içeren View döner.</returns>
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7003/api/Testimonials");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
                return View(data);
            }
            return View();
        }

        /// <summary>
        /// Yeni bir Testimonial oluşturma sayfasını getirir.
        /// </summary>
        /// <returns>Yeni Testimonial oluşturma görünümü döner.</returns>
        [HttpGet]
        [Route("CreateTestimonial")]
        public IActionResult CreateTestimonial()
        {
            return View();
        }

        /// <summary>
        /// Yeni bir Testimonial oluşturur.
        /// </summary>
        /// <param name="createTestimonialDto">Oluşturulacak Testimonial'ın bilgilerini içeren DTO nesnesi.</param>
        /// <returns>
        /// Başarılıysa Index sayfasına yönlendirir.
        /// Başarısızsa mevcut görünümü döner.
        /// </returns>
        [HttpPost]
        [Route("CreateTestimonial")]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createTestimonialDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7003/api/Testimonials", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Testimonial", new { area = "Admin" });
            }
            return View();
        }

        /// <summary>
        /// Belirli bir Testimonial'ı siler.
        /// </summary>
        /// <param name="id">Silinecek Testimonial'ın benzersiz kimliği.</param>
        /// <returns>
        /// Başarılıysa Index sayfasına yönlendirir.
        /// Başarısızsa mevcut görünümü döner.
        /// </returns>
        [Route("RemoveTestimonial/{id}")]
        public async Task<IActionResult> RemoveTestimonial(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7003/api/Testimonials/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Testimonial", new { area = "Admin" });
            }
            return View();
        }

        /// <summary>
        /// Belirli bir Testimonial'ın güncelleme sayfasını getirir.
        /// </summary>
        /// <param name="id">Güncellenecek Testimonial'ın benzersiz kimliği.</param>
        /// <returns>
        /// Güncellenecek Testimonial'ın bilgilerini içeren View döner.
        /// </returns>
        [HttpGet]
        [Route("UpdateTestimonial/{id}")]
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7003/api/Testimonials/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<UpdateTestimonialDto>(jsonData);
                return View(data);
            }
            return View();
        }

        /// <summary>
        /// Belirli bir Testimonial'ı günceller.
        /// </summary>
        /// <param name="updateTestimonialDto">Güncellenecek Testimonial'ın bilgilerini içeren DTO nesnesi.</param>
        /// <returns>
        /// Güncelleme başarılıysa Index sayfasına yönlendirir.
        /// Güncelleme başarısız olursa mevcut görünümü döner.
        /// </returns>
        [HttpPost]
        [Route("UpdateTestimonial/{id}")]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateTestimonialDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"https://localhost:7003/api/Testimonials/", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Testimonial", new { area = "Admin" });
            }
            return View();
        }
    }
}
