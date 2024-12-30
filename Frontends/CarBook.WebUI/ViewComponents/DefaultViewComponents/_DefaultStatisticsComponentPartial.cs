using CarBook.DTO.StatisticDtos;
using CarBook.WebUI.ApiSettings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultStatisticsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly string statisticsBaseUrl;

        public _DefaultStatisticsComponentPartial(IHttpClientFactory httpClientFactory, IOptions<StatisticsApiOptions> statisticsApiOptions)
        {
            this.httpClientFactory = httpClientFactory;
            this.statisticsBaseUrl = statisticsApiOptions.Value.StatisticsBaseUrl;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = httpClientFactory.CreateClient();

            var endpoints = new Dictionary<string, Type>
            {
                { "CarCount", typeof(ResultCarCountDto) },
                { "LocationCount", typeof(ResultLocationCountDto) },
                { "BrandCount", typeof(ResultBrandCountDto) },
                { "CarCountElectric", typeof(ResultCarCountElectricDto) }
            };

            var viewModel = new ResultStatisticDto();

            foreach (var endpoint in endpoints)
            {
                var responseMessage = await client.GetAsync($"{statisticsBaseUrl}/{endpoint.Key}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var dtoType = endpoint.Value;

                    var data = JsonConvert.DeserializeObject(jsonData, dtoType);

                    switch (data)
                    {
                        case ResultCarCountDto dto:
                            viewModel.CarCount = dto.CarCount;
                            break;
                        case ResultLocationCountDto dto:
                            viewModel.LocationCount = dto.LocationCount;
                            break;
                        case ResultBrandCountDto dto:
                            viewModel.BrandCount = dto.BrandCount;
                            break;
                        case ResultCarCountElectricDto dto:
                            viewModel.CarCountElectric = dto.CarCount;
                            break;
                    }
                }
            }

            return View(viewModel);
        }
    }
}
