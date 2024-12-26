using CarBook.Application.Features.Mediator.Commands.LocationCommands;
using CarBook.Application.Features.Mediator.Queries.LocationQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly IMediator mediator;
        public LocationsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> LocationList()
        {
            var data = await mediator.Send(new GetLocationQuery());
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocation(int id)
        {
            var data = await mediator.Send(new GetLocationByIdQuery(id));
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocation(CreateLocationCommand command)
        {
            await mediator.Send(command);
            return Ok("Location Created");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLocation(UpdateLocationCommand command)
        {
            await mediator.Send(command);
            return Ok("Location Updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveLocation(RemoveLocationCommand command)
        {
            await mediator.Send(command);
            return Ok("Location Deleted");
        }
    }
}
