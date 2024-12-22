using CarBook.Application.Features.Mediator.Commands.FooterAddressCommands;
using CarBook.Application.Features.Mediator.Queries.FooterAddressQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAddressesController : ControllerBase
    {
        private readonly IMediator mediator;
        public FooterAddressesController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> FooterAddressList()
        {
            var data = await mediator.Send(new GetFooterAddressQuery());
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFooterAddress(int id)
        {
            var data = await mediator.Send(new GetFooterAddressByIdQuery(id));
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFooterAddress(CreateFooterAddressCommand command)
        {
            await mediator.Send(command);
            return Ok("Footer Address Created");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFooterAddress(UpdateFooterAddressCommand command)
        {
            await mediator.Send(command);
            return Ok("Footer Address Updated");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveFooterAddress(RemoveFooterAddressCommand command)
        {
            await mediator.Send(command);
            return Ok("Footer Address Deleted");
        }
    }
}
