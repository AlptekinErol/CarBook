using CarBook.Application.Features.Mediator.Commands.ReservationCommands;
using CarBook.Application.Interfaces;
using CarBook.Common.Constans;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommandHandlers.ReservationHandlers
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand>
    {
        private readonly IRepository<Reservation> repository;
        public CreateReservationCommandHandler(IRepository<Reservation> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            await repository.CreateAsync(new Reservation
            {
                Age = request.Age,
                Status = ReservationConstants.ReservationReceived,
                CarId = request.CarId,
                Description = request.Description,
                DropOffLocationId = request.DropOffLocationId,
                PickUpLocationId = request.PickUpLocationId,
                EMail = request.EMail,
                Phone = request.Phone,
                DriverLicenseYear = request.DriverLicenseYear,
                Name = request.Name,
                Surname = request.Surname,
            });
        }
    }
}
