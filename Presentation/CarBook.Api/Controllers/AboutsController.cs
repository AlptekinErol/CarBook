using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Features.CQRS.Handlers.CommandHandlers.AboutHandlers;
using CarBook.Application.Features.CQRS.Handlers.QueryHandlers.AboutHandlers;
using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly CreateAboutCommandHandler createAboutCommandHandler;
        private readonly GetAboutByIdQueryHandler getAboutByIdQueryHandler;
        private readonly GetAboutQueryHandler getAboutQueryHandler;
        private readonly RemoveAboutCommandHandler removeAboutCommandHandler;
        private readonly UpdateAboutCommandHandler updateAboutCommandHandler;

        public AboutsController(CreateAboutCommandHandler createAboutCommandHandler,
               GetAboutByIdQueryHandler getAboutByIdQueryHandler,
               GetAboutQueryHandler getAboutQueryHandler,
               RemoveAboutCommandHandler removeAboutCommandHandler,
               UpdateAboutCommandHandler updateAboutCommandHandler)
        {
            this.createAboutCommandHandler = createAboutCommandHandler;
            this.getAboutByIdQueryHandler = getAboutByIdQueryHandler;
            this.getAboutQueryHandler = getAboutQueryHandler;
            this.removeAboutCommandHandler = removeAboutCommandHandler;
            this.updateAboutCommandHandler = updateAboutCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var data = await getAboutQueryHandler.Handle();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAboutById(int id) // parametre olarak GetAboutByIdQuery sınıfıda geçilebilir ama controller'ın işi kendi, class'ın işi kendine olsun diye ayırdık
        {
            var data = await getAboutByIdQueryHandler.Handle(new GetAboutByIdQuery(id));
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutCommand command)
        {
            await createAboutCommandHandler.Handle(command);
            return Ok("About Created");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAbout(int id)
        {
            await removeAboutCommandHandler.Handle(new RemoveAboutCommand(id));
            return Ok("About removed");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommand command)
        {
            await updateAboutCommandHandler.Handle(command);
            return Ok("About Updated");
        }

    }
}
