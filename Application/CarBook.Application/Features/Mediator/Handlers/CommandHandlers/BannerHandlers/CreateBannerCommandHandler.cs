using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.CommandHandlers.BannerHandlers
{
    public class CreateBannerCommandHandler : IRequestHandler<CreateBannerCommand>
    {
        private readonly IRepository<Banner> repository;
        public CreateBannerCommandHandler(IRepository<Banner> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(CreateBannerCommand request, CancellationToken cancellationToken)
        {
            await repository.CreateAsync(new Banner
            {
                CreatedDate = DateTime.Now,
                UpdatedDate = request.UpdatedDate,
                Description = request.Description,
                Title = request.Title,
                VideoDescription = request.VideoDescription,
                VideoUrl = request.VideoUrl
            });
        }
    }
}
