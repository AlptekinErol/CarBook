using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CommandHandlers.CarHandlers
{
    public class CreateCarCommandHandler
    {
        private readonly IRepository<Car> repository;
        public CreateCarCommandHandler(IRepository<Car> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(CreateCarCommand command)
        {
            await repository.CreateAsync(new Car
            {
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                BigImageUrl = command.BigImageUrl,
                BrandId = command.BrandId,
                CoverImageUrl = command.CoverImageUrl,
                Fuel = command.Fuel,
                Km = command.Km,
                Transmission = command.Transmission,
                Luggage = command.Luggage,
                Seat = command.Seat,
                Model = command.Model,
            });
        }
    }
}
