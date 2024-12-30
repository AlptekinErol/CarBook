using CarBook.Application.Features.Mediator.Commands.ReservationCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IMediator mediator;
        public ReservationsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateReservationCommand command)
        {
            await mediator.Send(command);
            return Ok("Reservation Created");
        }
    }
}
