using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CommandHandlers.ContactHandlers
{
    public class UpdateContactCommandHandler
    {
        private readonly IRepository<Contact> repository;
        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(UpdateContactCommand command)
        {
            var data = await repository.GetByIdAsync(command.ContactId);
            data.EMail = command.EMail;
            data.Subject = command.Subject;
            data.Name = command.Name;
            data.SendDate = command.SendDate;
            data.CreatedDate = command.CreatedDate;
            data.UpdatedDate = DateTime.Now;
            await repository.UpdateAsync(data);
        }
    }
}
