using CarBook.DTO.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlogBook.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public BlogController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Bloglar";
            ViewBag.v2 = "Yazarlarımızın Blogları";
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7003/api/Blogs/BlogsWithAuthor");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<ResultBlogsWithAuthorDto>>(jsonData);

                return View(data);
            }
            return View();
        }

        public async Task<IActionResult> SingleBlogDetails(int id)
        {
            ViewBag.v1 = "Bloglar";
            ViewBag.v2 = "Single Blog Detayı ve Yorumlar";
            ViewBag.blogid = id;
            return View();
        }
    }
}
