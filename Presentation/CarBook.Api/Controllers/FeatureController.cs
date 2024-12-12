using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using CarBook.Application.Features.Mediator.Queries.FooterAddressQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IMediator mediator;
        public FeatureController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> FeatureList()
        {
            var data = await mediator.Send(new GetFeatureQuery()); // burada new GetFeatureQuery vermemizin sebebi aslında bu sınıfın bir Request olduğunu belirttik Request'in imzası denebilir ( Feature sınıfına ait imza ) 
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeature(int id)
        {
            var data = await mediator.Send(new GetFooterAddressByIdQuery(id));
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureCommand command)
        {
            await mediator.Send(command);
            return Ok("Feature Created");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureCommand command)
        {
            await mediator.Send(command);
            return Ok("Feature Updated");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveFeature(RemoveFeatureCommand command)
        {
            await mediator.Send(command);
            return Ok("Feature Deleted");
        }
    }
}
