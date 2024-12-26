using CarBook.Application.Features.Mediator.Commands.CarCommands;
using CarBook.Application.Features.Mediator.Queries.CarQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IMediator mediator;
        public CarsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CarList()
        {
            var data = await mediator.Send(new GetCarQuery());
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCar(int id)
        {
            var data = await mediator.Send(new GetCarByIdQuery(id));
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarCommand command)
        {
            await mediator.Send(command);
            return Ok("Car Created");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
        {
            await mediator.Send(command);
            return Ok("Car Updated");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCar(RemoveCarCommand command)
        {
            await mediator.Send(command);
            return Ok("Car Deleted");
        }
    }
}
