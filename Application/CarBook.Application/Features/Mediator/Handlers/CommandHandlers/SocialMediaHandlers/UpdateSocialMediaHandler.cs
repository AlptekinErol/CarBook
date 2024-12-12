using CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommandHandlers.SocialMediaHandlers
{
    public class UpdateSocialMediaHandler : IRequestHandler<UpdateSocialMediaCommand>
    {
        private readonly IRepository<SocialMedia> repository;
        public UpdateSocialMediaHandler(IRepository<SocialMedia> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var data = await repository.GetByIdAsync(request.SocialMediaId);
            data.Icon = request.Icon;
            data.Name = request.Name;
            data.Url = request.Url;
            data.CreatedDate = request.CreatedDate;
            data.UpdatedDate = DateTime.UtcNow;

            await repository.UpdateAsync(data);
        }
    }
}
