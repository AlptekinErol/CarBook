using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CommandHandlers.ContactHandlers
{
    public class CreateContactCommandHandler
    {
        private readonly IRepository<Contact> repository;
        public CreateContactCommandHandler(IRepository<Contact> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(CreateContactCommand command)
        {
            await repository.CreateAsync(new Contact
            {
                CreatedDate = DateTime.Now,
                EMail = command.EMail,
                Message = command.Message,
                Name = command.Name,
                SendDate = command.SendDate,
                Subject = command.Subject,
                UpdatedDate = command.UpdatedDate
            });
        }
    }
}
