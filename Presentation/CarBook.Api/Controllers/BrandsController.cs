using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Features.CQRS.Commands.Brands;
using CarBook.Application.Features.CQRS.Handlers.CommandHandlers.BrandCommandHandlers;
using CarBook.Application.Features.CQRS.Handlers.QueryHandlers.BrandHandlers;
using CarBook.Application.Features.CQRS.Queries.BrandQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly GetBrandQueryHandler getBrandQueryHandler;
        private readonly GetBrandByIdQueryHandler getBrandByIdQueryHandler;
        private readonly CreateBrandCommandHandler createBrandCommandHandler;
        private readonly UpdateBrandCommandHandler updateBrandCommandHandler;
        private readonly RemoveBrandCommandHandler removeBrandCommandHandler;

        public BrandsController(GetBrandQueryHandler getBrandQueryHandler, 
            GetBrandByIdQueryHandler getBrandByIdQueryHandler, 
            CreateBrandCommandHandler createBrandCommandHandler, 
            UpdateBrandCommandHandler updateBrandCommandHandler, 
            RemoveBrandCommandHandler removeBrandCommandHandler)
        {
            this.getBrandQueryHandler = getBrandQueryHandler;
            this.getBrandByIdQueryHandler = getBrandByIdQueryHandler;
            this.createBrandCommandHandler = createBrandCommandHandler;
            this.updateBrandCommandHandler = updateBrandCommandHandler;
            this.removeBrandCommandHandler = removeBrandCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> BrandList()
        {
            var data = await getBrandQueryHandler.Handle();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandById(int id)
        {
            var data = await getBrandByIdQueryHandler.Handle(new GetBrandByIdQuery(id));
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandCommand command)
        {
            await createBrandCommandHandler.Handle(command);
            return Ok("Brand created");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBrand(UpdateBrandCommand command)
        {
            await updateBrandCommandHandler.Handle(command);
            return Ok("Brand updated");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveBrand(int id)
        {
            await removeBrandCommandHandler.Handle(new RemoveBrandCommand(id));
            return Ok("Brand deleted");
        }
    }
}
