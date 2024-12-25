using CarBook.Application.Features.CQRS.Commands.CategoryCommands;
using CarBook.Application.Features.CQRS.Handlers.CommandHandlers.CategoryHandlers;
using CarBook.Application.Features.CQRS.Handlers.QueryHandlers.CategoryHandlers;
using CarBook.Application.Features.CQRS.Queries.CategoryQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly GetCategoryQueryHandler getCategoryQueryHandler;
        private readonly GetCategoryByIdQueryHandler getCategoryByIdQueryHandler;
        private readonly CreateCategoryCommandHandler createCategoryCommandHandler;
        private readonly UpdateCategoryCommandHandler updateCategoryCommandHandler;
        private readonly RemoveCategoryCommandHandler removeCategoryCommandHandler;

        public CategoriesController(GetCategoryQueryHandler getCategoryQueryHandler,
            GetCategoryByIdQueryHandler getCategoryByIdQueryHandler,
            CreateCategoryCommandHandler createCategoryCommandHandler,
            UpdateCategoryCommandHandler updateCategoryCommandHandler,
            RemoveCategoryCommandHandler removeCategoryCommandHandler)
        {
            this.getCategoryQueryHandler = getCategoryQueryHandler;
            this.getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
            this.createCategoryCommandHandler = createCategoryCommandHandler;
            this.updateCategoryCommandHandler = updateCategoryCommandHandler;
            this.removeCategoryCommandHandler = removeCategoryCommandHandler;
        }


        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var data = await getCategoryQueryHandler.Handle();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var data = await getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            await createCategoryCommandHandler.Handle(command);
            return Ok("Category created");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            await updateCategoryCommandHandler.Handle(command);
            return Ok("Category updated");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBrand(int id)
        {
            await removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));
            return Ok("Category deleted");
        }
    }
}
