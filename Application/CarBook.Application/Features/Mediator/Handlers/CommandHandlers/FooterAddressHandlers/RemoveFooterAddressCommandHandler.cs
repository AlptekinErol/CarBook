using CarBook.Application.Features.Mediator.Commands.FooterAddressCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommandHandlers.FooterAddressHandlers
{
    public class RemoveFooterAddressCommandHandler : IRequestHandler<RemoveFooterAddressCommand>
    {
        private readonly IRepository<FooterAddress> repository;
        public RemoveFooterAddressCommandHandler(IRepository<FooterAddress> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(RemoveFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var data = await repository.GetByIdAsync(request.Id);
            await repository.RemoveAsync(data);
        }
    }
}
