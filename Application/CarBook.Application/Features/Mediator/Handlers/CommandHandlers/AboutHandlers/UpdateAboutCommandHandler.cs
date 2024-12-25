using CarBook.Application.Features.Mediator.Commands.AboutCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommandHandlers.AboutHandlers
{
    public class UpdateAboutCommandHandler : IRequestHandler<UpdateAboutCommand>
    {
        private readonly IRepository<About> repository;
        public UpdateAboutCommandHandler(IRepository<About> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(UpdateAboutCommand request, CancellationToken cancellationToken)
        {
            var data = await repository.GetByIdAsync(request.AboutId);

            data.Title = request.Title;
            data.Description = request.Description;
            data.CreatedDate = request.CreatedDate;
            data.ImageUrl = request.ImageUrl;
            data.UpdatedDate = DateTime.Now;
            await repository.UpdateAsync(data);
        }
    }
}
