using CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommandHandlers.SocialMediaHandlers
{
    public class CreateSocialMediaHandler : IRequestHandler<CreateSocialMediaCommand>
    {
        private readonly IRepository<SocialMedia> repository;
        public CreateSocialMediaHandler(IRepository<SocialMedia> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            await repository.CreateAsync(new SocialMedia
            {
                Icon = request.Icon,
                Name = request.Name,
                Url = request.Url,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = request.UpdatedDate
            });
        }
    }
}
