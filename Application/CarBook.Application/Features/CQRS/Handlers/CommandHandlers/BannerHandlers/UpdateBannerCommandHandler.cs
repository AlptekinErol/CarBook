using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CommandHandlers.BannerHandlers
{
    public class UpdateBannerCommandHandler
    {
        private readonly IRepository<Banner> repository;
        public UpdateBannerCommandHandler(IRepository<Banner> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(UpdateBannerCommand command)
        {
            var data = await repository.GetByIdAsync(command.BannerId);
            data.Description = command.Description;
            data.Title = command.Title;
            data.VideoDescription = command.VideoDescription;
            data.VideoUrl= command.VideoUrl;
            data.CreatedDate= command.CreatedDate;
            data.UpdatedDate= command.UpdatedDate;
        }
    }
}
