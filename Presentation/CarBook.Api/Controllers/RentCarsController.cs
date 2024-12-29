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

        [HttpGet]
        public async Task<IActionResult> GetRentCarListByLocation(int locationId, bool availabe)
        {
            GetRentCarQuery getRentCarQuery = new GetRentCarQuery()
            {
                CarAvailable = availabe,
                LocationId = locationId
            };
            var data = await mediator.Send(getRentCarQuery);
            return Ok(data);
        }
    }
}
