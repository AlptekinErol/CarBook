using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Features.CQRS.Handlers.CommandHandlers.ContactHandlers;
using CarBook.Application.Features.CQRS.Handlers.QueryHandlers.ContactHandlers;
using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly GetContactQueryHandler getContactQueryHandler;
        private readonly GetContactByIdQueryHandler getContactByIdQueryHandler;
        private readonly CreateContactCommandHandler createContactCommandHandler;
        private readonly UpdateContactCommandHandler updateContactCommandHandler;
        private readonly RemoveContactCommandHandler removeContactCommandHandler;

        public ContactsController(GetContactQueryHandler getContactQueryHandler,
            GetContactByIdQueryHandler getContactByIdQueryHandler,
            CreateContactCommandHandler createContactCommandHandler,
            UpdateContactCommandHandler updateContactCommandHandler,
            RemoveContactCommandHandler removeContactCommandHandler)
        {
            this.getContactQueryHandler = getContactQueryHandler;
            this.getContactByIdQueryHandler = getContactByIdQueryHandler;
            this.createContactCommandHandler = createContactCommandHandler;
            this.updateContactCommandHandler = updateContactCommandHandler;
            this.removeContactCommandHandler = removeContactCommandHandler;
        }


        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var data = await getContactQueryHandler.Handle();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(int id)
        {
            var data = await getContactByIdQueryHandler.Handle(new GetContactByIdQuery(id));
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactCommand command)
        {
            await createContactCommandHandler.Handle(command);
            return Ok("Contact created");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactCommand command)
        {
            await updateContactCommandHandler.Handle(command);
            return Ok("Contact updated");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveBrand(int id)
        {
            await removeContactCommandHandler.Handle(new RemoveContactCommand(id));
            return Ok("Contact deleted");
        }
    }
}
