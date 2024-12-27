using CarBook.Application.Features.Mediator.Queries.StatisticQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IMediator mediator;
        public StatisticsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("CarCount")]
        public async Task<IActionResult> GetCarCount()
        {
            var data = await mediator.Send(new GetCarCountQuery());
            return Ok(data);
        }

        [HttpGet("LocationCount")]
        public async Task<IActionResult> GetLocationCount()
        {
            var data = await mediator.Send(new GetLocationCountQuery());
            return Ok(data);
        }

        [HttpGet("AuthorCount")]
        public async Task<IActionResult> GetAuthorCount()
        {
            var data = await mediator.Send(new GetAuthorCountQuery());
            return Ok(data);
        }

        [HttpGet("BlogCount")]
        public async Task<IActionResult> GetBlogCount()
        {
            var data = await mediator.Send(new GetBlogCountQuery());
            return Ok(data);
        }

        [HttpGet("BrandCount")]
        public async Task<IActionResult> GetBrandCount()
        {
            var data = await mediator.Send(new GetBrandCountQuery());
            return Ok(data);
        }

        [HttpGet("AverageDailyRentPrice")]
        public async Task<IActionResult> AverageDailyRentPrice()
        {
            var data = await mediator.Send(new GetAverageDailyRentPriceQuery());
            return Ok(data);
        }

        [HttpGet("AverageWeeklyRentPrice")]
        public async Task<IActionResult> AverageWeeklyRentPrice()
        {
            var data = await mediator.Send(new GetAverageWeeklyRentPriceQuery());
            return Ok(data);
        }

        [HttpGet("AverageMonthlyRentPrice")]
        public async Task<IActionResult> AverageMonthlyRentPrice()
        {
            var data = await mediator.Send(new GetAverageMonthlyRentPriceQuery());
            return Ok(data);
        }

        [HttpGet("CarCountByTransmissionIsAuto")]
        public async Task<IActionResult> GetCarCountByTransmissionIsAuto()
        {
            var data = await mediator.Send(new GetCarCountByTransmissionAutoQuery());
            return Ok(data);
        }

        [HttpGet("BrandNameByMaxCarCount")]
        public async Task<IActionResult> BrandNameByMaxCarCount()
        {
            var data = await mediator.Send(new GetBrandNameByMaxCarCountQuery());
            return Ok(data);
        }

        [HttpGet("BlogTitleByMaxComment")]
        public async Task<IActionResult> BlogTitleByMaxComment()
        {
            var data = await mediator.Send(new GetBlogTitleByMaxCommentQuery());
            return Ok(data);
        }

        [HttpGet("CarCountKmLessThen1000")]
        public async Task<IActionResult> GetCarCountKmLessThen1000()
        {
            var data = await mediator.Send(new GetCarCountKmLessThen1000Query());
            return Ok(data);
        }

        [HttpGet("CarCountByFuelType")]
        public async Task<IActionResult> GetCarCountByFuelType()
        {
            var data = await mediator.Send(new GetCarCountByFuelTypeQuery());
            return Ok(data);
        }

        [HttpGet("CarCountElectric")]
        public async Task<IActionResult> GetCarCountElectric()
        {
            var data = await mediator.Send(new GetCarCountElectricQuery());
            return Ok(data);
        }

        [HttpGet("CarModelByRentPriceDailyMax")]
        public async Task<IActionResult> GetCarBrandAndModelByRentPriceDailyMax()
        {
            var data = await mediator.Send(new GetCarBrandAndModelByRentPriceDailyMaxQuery());
            return Ok(data);
        }

        [HttpGet("CarModelByRentPriceDailyMin")]
        public async Task<IActionResult> GetCarBrandAndModelByRentPriceDailyMin()
        {
            var data = await mediator.Send(new GetCarBrandAndModelByRentPriceDailyMinQuery());
            return Ok(data);
        }
    }
}
