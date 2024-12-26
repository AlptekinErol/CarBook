using CarBook.DTO.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Blog")]
    public class BlogController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public BlogController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// Tüm Blog'ları listeleyen sayfayı getirir.
        /// </summary>
        /// <returns>Blog listesini içeren View döner.</returns>
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7003/api/Blogs");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<ResultBlogsWithAuthorDto>>(jsonData);
                return View(data);
            }
            return View();
        }

        /// <summary>
        /// Belirli bir Blog'ı siler.
        /// </summary>
        /// <param name="id">Silinecek Blog'ın benzersiz kimliği.</param>
        /// <returns>
        /// Başarılıysa Index sayfasına yönlendirir.
        /// Başarısızsa mevcut görünümü döner.
        /// </returns>
        [Route("RemoveBlog/{id}")]
        public async Task<IActionResult> RemoveBlog(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7003/api/Blogs/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Blog", new { area = "Admin" });
            }
            return View();
        }
    }
}
