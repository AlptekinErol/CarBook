using CarBook.Application.Features.Mediator.Commands.FooterAddressCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommandHandlers.FooterAddressHandlers
{
    public class CreateFooterAddressCommandHandler : IRequestHandler<CreateFooterAddressCommand>
    {
        private readonly IRepository<FooterAddress> repository;
        public CreateFooterAddressCommandHandler(IRepository<FooterAddress> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(CreateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            await repository.CreateAsync(new FooterAddress
            {
                Address = request.Address,
                Description = request.Description,
                EMail = request.EMail,
                Phone = request.Phone,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = request.UpdatedDate
            });
        }
    }
}
