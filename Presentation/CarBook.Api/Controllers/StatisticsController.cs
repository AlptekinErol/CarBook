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
    }
}
