using CarBook.Application.Features.Mediator.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommandHandlers.CarHandlers
{
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand>
    {
        private readonly IRepository<Car> repository;
        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            var data = await repository.GetByIdAsync(request.CarId);
            data.Fuel = request.Fuel;
            data.Transmission = request.Transmission;
            data.BigImageUrl = request.BigImageUrl;
            data.BrandId = request.BrandId;
            data.CoverImageUrl = request.CoverImageUrl;
            data.Km = request.Km;
            data.Luggage = request.Luggage;
            data.Seat = request.Seat;
            data.Model = request.Model;
            await repository.UpdateAsync(data);
        }
    }
}
