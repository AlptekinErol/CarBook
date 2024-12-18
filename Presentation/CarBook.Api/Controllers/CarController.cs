using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Features.CQRS.Handlers.CommandHandlers.CarHandlers;
using CarBook.Application.Features.CQRS.Handlers.QueryHandlers.CarHandlers;
using CarBook.Application.Features.CQRS.Queries.CarQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly GetCarQueryHandler getCarQueryHandler;
        private readonly GetCarByIdQueryHandler getCarByIdQueryHandler;
        private readonly CreateCarCommandHandler createCarCommandHandler;
        private readonly UpdateCarCommandHandler updateCarCommandHandler;
        private readonly RemoveCarCommandHandler removeCarCommandHandler;
        private readonly GetCarWithBrandQueryHandler getCarWithBrandQueryHandler;
        private readonly Get5CarWithBrandQueryHandler get5CarWithBrandQueryHandler;

        public CarController(GetCarQueryHandler getCarQueryHandler,
            GetCarByIdQueryHandler getCarByIdQueryHandler,
            CreateCarCommandHandler createCarCommandHandler,
            UpdateCarCommandHandler updateCarCommandHandler,
            RemoveCarCommandHandler removeCarCommandHandler,
            GetCarWithBrandQueryHandler getCarWithBrandQueryHandler,
            Get5CarWithBrandQueryHandler get5CarWithBrandQueryHandler)
        {
            this.getCarQueryHandler = getCarQueryHandler;
            this.getCarByIdQueryHandler = getCarByIdQueryHandler;
            this.createCarCommandHandler = createCarCommandHandler;
            this.updateCarCommandHandler = updateCarCommandHandler;
            this.removeCarCommandHandler = removeCarCommandHandler;
            this.getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;
            this.get5CarWithBrandQueryHandler = get5CarWithBrandQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> CarList()
        {
            var data = await getCarQueryHandler.Handle();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarById(int id)
        {
            var data = await getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarCommand command)
        {
            await createCarCommandHandler.Handle(command);
            return Ok("Car created");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
        {
            await updateCarCommandHandler.Handle(command);
            return Ok("Car updated");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCar(int id)
        {
            await removeCarCommandHandler.Handle(new RemoveCarCommand(id));
            return Ok("Car deleted");
        }
        [HttpGet("GetCarWithBrand")]
        public IActionResult GetCarWithBrand()
        {
            var data = getCarWithBrandQueryHandler.Handle();
            return Ok(data);
        }

        [HttpGet("Get5CarWithBrand")]
        public IActionResult Get5CarWithBrand()
        {
            var data = get5CarWithBrandQueryHandler.Handle();
            return Ok(data);
        }

    }
}
