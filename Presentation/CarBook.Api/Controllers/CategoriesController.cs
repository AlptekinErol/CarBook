using CarBook.Application.Features.Mediator.Commands.CategoryCommands;
using CarBook.Application.Features.Mediator.Queries.CategoryQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator mediator;
        public CategoriesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var data = await mediator.Send(new GetCategoryQuery());
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var data = await mediator.Send(new GetCategoryByIdQuery(id));
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            await mediator.Send(command);
            return Ok("Category Created");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            await mediator.Send(command);
            return Ok("Category Updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCategory(RemoveCategoryCommand command)
        {
            await mediator.Send(command);
            return Ok("Category Deleted");
        }
    }
}
