using CarBook.Application.Features.Mediator.Commands.BannerCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommandHandlers.BannerHandlers
{
    public class RemoveBannerCommandHandler : IRequestHandler<RemoveBannerCommand>
    {
        private readonly IRepository<Banner> repository;
        public RemoveBannerCommandHandler(IRepository<Banner> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(RemoveBannerCommand request, CancellationToken cancellationToken)
        {
            var data = await repository.GetByIdAsync(request.Id);
            await repository.RemoveAsync(data);
        }
    }
}
