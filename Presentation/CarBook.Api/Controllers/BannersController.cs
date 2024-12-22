using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Features.CQRS.Handlers.CommandHandlers.BannerHandlers;
using CarBook.Application.Features.CQRS.Handlers.QueryHandlers.BannerHandlers;
using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using Microsoft.AspNetCore.Mvc;


namespace CarBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly GetBannerQueryHandler getBannerQueryHandler;
        private readonly GetBannerByIdQueryHandler getBannerByIdQueryHandler;
        private readonly CreateBannerCommandHandler createBannerCommandHandler;
        private readonly UpdateBannerCommandHandler updateBannerCommandHandler;
        private readonly RemoveBannerCommandHandler removeBannerCommandHandler;

        public BannersController(GetBannerQueryHandler getBannerQueryHandler,
            GetBannerByIdQueryHandler getBannerByIdQueryHandler,
            CreateBannerCommandHandler createBannerCommandHandler,
            UpdateBannerCommandHandler updateBannerCommandHandler,
            RemoveBannerCommandHandler removeBannerCommandHandler)
        {
            this.getBannerQueryHandler = getBannerQueryHandler;
            this.getBannerByIdQueryHandler = getBannerByIdQueryHandler;
            this.createBannerCommandHandler = createBannerCommandHandler;
            this.updateBannerCommandHandler = updateBannerCommandHandler;
            this.removeBannerCommandHandler = removeBannerCommandHandler;
        }


        [HttpGet]
        public async Task<IActionResult> BannerList()
        {
            var data = await getBannerQueryHandler.Handle();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBannerById(int id)
        {
            var data = await getBannerByIdQueryHandler.Handle(new GetBannerByIdQuery(id));
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerCommand command)
        {
            await createBannerCommandHandler.Handle(command);
            return Ok("Banner created");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBanner(UpdateBannerCommand command)
        {
            await updateBannerCommandHandler.Handle(command);
            return Ok("Banner updated");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveBrand(int id)
        {
            await removeBannerCommandHandler.Handle(new RemoveBannerCommand(id));
            return Ok("Banner deleted");
        }
    }
}
