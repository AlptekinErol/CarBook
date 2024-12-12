using CarBook.Application.Features.Mediator.Commands.FooterAddressCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommandHandlers.FooterAddressHandlers
{
    public class UpdateFooterAddressCommandHandler : IRequestHandler<UpdateFooterAddressCommand>
    {
        private readonly IRepository<FooterAddress> repository;
        public UpdateFooterAddressCommandHandler(IRepository<FooterAddress> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var data = await repository.GetByIdAsync(request.FooterAddressId);
            data.Description = request.Description;
            data.Address = request.Address;
            data.EMail = request.EMail;
            data.Phone = request.Phone;
            data.CreatedDate = request.CreatedDate;
            data.UpdatedDate = DateTime.UtcNow;

            await repository.UpdateAsync(data);
        }
    }
}
