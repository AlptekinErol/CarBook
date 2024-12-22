using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get the list of Features.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> FeatureList()
        {
            var data = await _mediator.Send(new GetFeatureQuery());
            return Ok(data);
        }

        /// <summary>
        /// Get a specific Feature by ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeature(int id)
        {
            var data = await _mediator.Send(new GetFeatureByIdQuery(id));
            return Ok(data);
        }

        /// <summary>
        /// Create a new Feature.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureCommand command)
        {
            await _mediator.Send(command);
            return Ok("Feature Created");
        }

        /// <summary>
        /// Update an existing Feature.
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureCommand command)
        {
            await _mediator.Send(command);
            return Ok("Feature Updated");
        }

        /// <summary>
        /// Remove a Feature by ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveFeature(int id)
        {
            await _mediator.Send(new RemoveFeatureCommand(id));
            return Ok("Feature Deleted");
        }
    }
}
