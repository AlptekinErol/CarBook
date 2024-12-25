using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.CommandHandlers.BannerHandlers
{
    public class UpdateBannerCommandHandler : IRequestHandler<UpdateBannerCommand>
    {
        private readonly IRepository<Banner> repository;
        public UpdateBannerCommandHandler(IRepository<Banner> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(UpdateBannerCommand request, CancellationToken cancellationToken)
        {
            var data = await repository.GetByIdAsync(request.BannerId);
            data.Description = request.Description;
            data.Title = request.Title;
            data.VideoDescription = request.VideoDescription;
            data.VideoUrl = request.VideoUrl;
            data.CreatedDate = request.CreatedDate;
            data.UpdatedDate = request.UpdatedDate;
            await repository.UpdateAsync(data);
        }
    }
}
