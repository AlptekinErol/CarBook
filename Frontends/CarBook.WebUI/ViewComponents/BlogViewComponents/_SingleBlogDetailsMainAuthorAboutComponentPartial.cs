using CarBook.DTO.AuthorDtos;
using CarBook.DTO.TagCloudDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _SingleBlogDetailsMainAuthorAboutComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory httpClientFactory;
        public _SingleBlogDetailsMainAuthorAboutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.v1 = id;
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7003/api/Blogs/BlogByAuthorId?id=" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var blogData = JsonConvert.DeserializeObject<List<ResultBlogByAuthorIdDto>>(jsonData);

                return View(blogData);
            }
            return View();
        }
    }
}
