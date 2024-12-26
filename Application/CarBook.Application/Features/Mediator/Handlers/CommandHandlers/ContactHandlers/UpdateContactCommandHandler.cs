using CarBook.Application.Features.Mediator.Commands.ContactCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommandHandlers.ContactHandlers
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand>
    {
        private readonly IRepository<Contact> repository;
        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var data = await repository.GetByIdAsync(request.ContactId);
            data.EMail = request.EMail;
            data.Subject = request.Subject;
            data.Name = request.Name;
            data.SendDate = request.SendDate;
            data.CreatedDate = request.CreatedDate;
            data.UpdatedDate = DateTime.Now;
            await repository.UpdateAsync(data);
        }
    }
}
