using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Features.Mediator.Queries.BannerQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly IMediator mediator;
        public BannersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> BannerList()
        {
            var data = await mediator.Send(new GetBannerQuery());
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBanner(int id)
        {
            var data = await mediator.Send(new GetBannerByIdQuery(id));
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerCommand command)
        {
            await mediator.Send(command);
            return Ok("Banner Created");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBanner(UpdateBannerCommand command)
        {
            await mediator.Send(command);
            return Ok("Banner Updated");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveBanner(RemoveBannerCommand command)
        {
            await mediator.Send(command);
            return Ok("Banner Deleted");
        }
    }
}
