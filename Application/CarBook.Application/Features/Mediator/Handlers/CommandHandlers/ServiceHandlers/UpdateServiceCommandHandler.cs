using CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommandHandlers.ServiceHandlers
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
    {
        private readonly IRepository<Service> repository;
        public UpdateServiceCommandHandler(IRepository<Service> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var data = await repository.GetByIdAsync(request.ServiceId);
            data.Description = request.Description;
            data.Title = request.Title;
            data.IconUrl = request.IconUrl;
            data.CreatedDate = request.CreatedDate;
            data.UpdatedDate = DateTime.UtcNow;

            await repository.UpdateAsync(data);
        }
    }
}
