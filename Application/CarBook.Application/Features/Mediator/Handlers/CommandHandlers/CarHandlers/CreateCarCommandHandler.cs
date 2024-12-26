using CarBook.Application.Features.Mediator.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommandHandlers.CarHandlers
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand>
    {
        private readonly IRepository<Car> repository;
        public CreateCarCommandHandler(IRepository<Car> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            await repository.CreateAsync(new Car
            {
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                BigImageUrl = request.BigImageUrl,
                BrandId = request.BrandId,
                CoverImageUrl = request.CoverImageUrl,
                Fuel = request.Fuel,
                Km = request.Km,
                Transmission = request.Transmission,
                Luggage = request.Luggage,
                Seat = request.Seat,
                Model = request.Model,
            });
        }
    }
}
