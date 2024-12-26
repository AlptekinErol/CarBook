using CarBook.Application.Features.Mediator.Commands.ContactCommands;
using CarBook.Application.Features.Mediator.Queries.ContactQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IMediator mediator;
        public ContactsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var data = await mediator.Send(new GetContactQuery());
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            var data = await mediator.Send(new GetContactByIdQuery(id));
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactCommand command)
        {
            await mediator.Send(command);
            return Ok("Contact Created");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactCommand command)
        {
            await mediator.Send(command);
            return Ok("Contact Updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveContact(RemoveContactCommand command)
        {
            await mediator.Send(command);
            return Ok("Contact Deleted");
        }
    }
}
