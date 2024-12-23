using CarBook.DTO.TagCloudDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _SingleBlogDetailsTagCloudComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory httpClientFactory;
        public _SingleBlogDetailsTagCloudComponentPartial(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7003/api/TagClouds/blog/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var blogData = JsonConvert.DeserializeObject<List<ResultGetTagCloudByBlogIdDto>>(jsonData);

                return View(blogData);
            }
            return View();
        }
    }
}
