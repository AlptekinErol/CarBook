using CarBook.DTO.BlogDtos;
using CarBook.DTO.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _SingleBlogDetailsCategoryComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory httpClientFactory;
        public _SingleBlogDetailsCategoryComponentPartial(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7003/api/Categories");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var blogData = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

                return View(blogData);
            }
            return View();
        }
    }
}
