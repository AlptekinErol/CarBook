using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CommandHandlers.BannerHandlers
{
    public class CreateBannerCommandHandler
    {
        private readonly IRepository<Banner> repository;
        public CreateBannerCommandHandler(IRepository<Banner> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(CreateBannerCommand command)
        {
            await repository.CreateAsync(new Banner
            {
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Description = command.Description,
                Title = command.Title,
                VideoDescription = command.VideoDescription,
                VideoUrl = command.VideoUrl
            });
        }
    }
}
