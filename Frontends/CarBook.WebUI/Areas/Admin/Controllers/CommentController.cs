using CarBook.DTO.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Comment")]
    public class CommentController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public CommentController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// Tüm Comment'ları listeleyen sayfayı getirir.
        /// </summary>
        /// <returns>Comment listesini içeren View döner.</returns>
        [HttpGet]
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7003/api/Comments/CommentByBlog?id={id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
                return View(data);
            }
            return View();
        }

        /// <summary>
        /// Belirli bir Comment'ı siler.
        /// </summary>
        /// <param name="id">Silinecek Comment'ın benzersiz kimliği.</param>
        /// <returns>
        /// Başarılıysa Index sayfasına yönlendirir.
        /// Başarısızsa mevcut görünümü döner.
        /// </returns>
        [Route("RemoveComment/{id}")]
        public async Task<IActionResult> RemoveComment(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7003/api/Comments/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Comment", new { area = "Admin" });
            }
            return View();
        }
    }
}
