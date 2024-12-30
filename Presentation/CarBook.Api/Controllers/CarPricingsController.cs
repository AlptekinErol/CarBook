using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPricingsController : ControllerBase
    {
        private readonly IMediator mediator;
        public CarPricingsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("Daily")]
        public async Task<IActionResult> GetCarPricingWithCarList()
        {
            var data = await mediator.Send(new GetCarPricingWithCarQuery());
            return Ok(data);
        }
        [HttpGet("CarPricingsWithTimePeriod")]
        public async Task<IActionResult> GetCarPricingWithTimePeriod()
        {
            var data = await mediator.Send(new GetCarPricingWithTimePeriodQuery());
            return Ok(data);
        }
    }
}
