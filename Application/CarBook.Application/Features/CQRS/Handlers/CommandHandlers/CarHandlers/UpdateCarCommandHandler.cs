using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CommandHandlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> repository;
        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(UpdateCarCommand command)
        {
            var data = await repository.GetByIdAsync(command.CarId);
            data.Fuel = command.Fuel;
            data.Transmission = command.Transmission;
            data.BigImageUrl = command.BigImageUrl;
            data.BrandId = command.BrandId;
            data.CoverImageUrl = command.CoverImageUrl;
            data.Km = command.Km;
            data.Luggage = command.Luggage;
            data.Seat = command.Seat;
            data.Model = command.Model;
            await repository.UpdateAsync(data);
        }
    }
}
