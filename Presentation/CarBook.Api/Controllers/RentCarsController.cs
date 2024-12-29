using CarBook.Application.Features.Mediator.Queries.RentCarQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentCarsController : ControllerBase
    {
        private readonly IMediator mediator;
        public RentCarsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> GetRentCarListByLocation(GetRentCarQuery query)
        {
            var data = await mediator.Send(query);
            return Ok(data);
        }
    }
}
