using CarBook.DTO.StatisticDtos;
using CarBook.WebUI.ApiSettings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Statistics")]
    public class StatisticsController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly string statisticsBaseUrl;
        public StatisticsController(IHttpClientFactory httpClientFactory, IOptions<StatisticsApiOptions> statisticsApiOptions)
        {
            this.httpClientFactory = httpClientFactory;
            this.statisticsBaseUrl = statisticsApiOptions.Value.StatisticsBaseUrl;
        }

        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            Random rnd = new Random();
            var client = httpClientFactory.CreateClient();
            var endpoints = new Dictionary<string, Type>
            {
                { "CarCount",typeof(ResultCarCountDto)},
                { "LocationCount",typeof(ResultLocationCountDto)},
                { "AuthorCount",typeof(ResultAuthorCountDto)},
                { "BlogCount",typeof(ResultBlogCountDto)},
                { "BrandCount",typeof(ResultBrandCountDto)},
                { "AverageDailyRentPrice",typeof(ResultAverageDailyRentPriceDto)},
                { "AverageWeeklyRentPrice",typeof(ResultAverageWeeklyRentPriceDto)},
                { "AverageMonthlyRentPrice",typeof(ResultAverageMonthlyRentPriceDto)},
                { "CarCountByTransmissionIsAuto",typeof(ResultAutoTransmissionCarCountDto)},
                { "BrandNameByMaxCarCount",typeof(ResultBrandNameByMaxCarCountDto)},
                { "BlogTitleByMaxComment",typeof(ResultBlogTitleByMaxCommentDto)},
                { "CarCountKmLessThen1000",typeof(ResultCarCountKmLessThen1000Dto)},
                { "CarCountByFuelType",typeof(ResultCarCountByFuelTypeDto)},
                { "CarCountElectric",typeof(ResultCarCountElectricDto)},
                { "CarModelByRentPriceDailyMax",typeof(ResultCarModelByRentPriceDailyMaxDto)},
                { "CarModelByRentPriceDailyMin",typeof(ResultCarModelByRentPriceDailyMinDto)},
            };
            var statisticsList = new List<dynamic>();

            foreach (var endpoint in endpoints)
            {
                //int v1 = rnd.Next(0, 101);
                var responseMessage = await client.GetAsync($"{statisticsBaseUrl}/{endpoint.Key}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var dtoType = endpoint.Value;

                    var data = JsonConvert.DeserializeObject(jsonData, dtoType);

                    object value = data switch
                    {
                        ResultCarCountDto dto => dto.CarCount,
                        ResultLocationCountDto dto => dto.LocationCount,
                        ResultAuthorCountDto dto => dto.AuthorCount,
                        ResultBlogCountDto dto => dto.BlogCount,
                        ResultBrandCountDto dto => dto.BrandCount,
                        ResultAverageDailyRentPriceDto dto => dto.Price,
                        ResultAverageWeeklyRentPriceDto dto => dto.Price,
                        ResultAverageMonthlyRentPriceDto dto => dto.Price,
                        ResultAutoTransmissionCarCountDto dto => dto.CarCount,
                        ResultBrandNameByMaxCarCountDto dto => dto.BrandName,
                        ResultBlogTitleByMaxCommentDto dto => dto.BlogTitle,
                        ResultCarCountKmLessThen1000Dto dto => dto.CarCount,
                        ResultCarCountByFuelTypeDto dto => dto.CarCount,
                        ResultCarCountElectricDto dto => dto.CarCount,
                        ResultCarModelByRentPriceDailyMaxDto dto => dto.Model,
                        ResultCarModelByRentPriceDailyMinDto dto => dto.Model,
                        _ => "Bilinmeyen veri türü"
                    };

                    statisticsList.Add(new
                    {
                        Endpoint = endpoint.Key,
                        Value = value,
                        RandomValue = rnd.Next(0, 101)
                    });
                }
            }
            return View(statisticsList);

            //var responseMessage = await client.GetAsync($"{statisticsBaseUrl}/CarCount");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    int v1 = rnd.Next(0, 101);
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var data = JsonConvert.DeserializeObject<ResultCarCountDto>(jsonData);
            //    ViewBag.v = data.CarCount;
            //    ViewBag.v1 = v1;
            //}
            //return View();
        }
    }
}
