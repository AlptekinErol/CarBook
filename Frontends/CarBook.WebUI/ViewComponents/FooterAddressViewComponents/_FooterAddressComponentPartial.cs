using CarBook.DTO.FooterAddressDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.FooterAddressViewComponents
{
    public class _FooterAddressComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory httpClientFactory;

        public _FooterAddressComponentPartial(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7003/api/FooterAddress");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<ResultFooterAddressDto>>(jsonData);

                return View(data);
            }
            return View();
        }
    }

}
