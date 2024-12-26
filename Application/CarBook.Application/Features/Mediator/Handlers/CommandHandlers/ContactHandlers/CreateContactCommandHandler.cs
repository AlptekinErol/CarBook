using CarBook.Application.Features.Mediator.Commands.ContactCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommandHandlers.ContactHandlers
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand>
    {
        private readonly IRepository<Contact> repository;
        public CreateContactCommandHandler(IRepository<Contact> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(CreateContactCommand command)
        {
            
        }

        public async Task Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            await repository.CreateAsync(new Contact
            {
                CreatedDate = DateTime.Now,
                EMail = request.EMail,
                Message = request.Message,
                Name = request.Name,
                SendDate = request.SendDate,
                Subject = request.Subject,
                UpdatedDate = request.UpdatedDate
            });
        }
    }
}
