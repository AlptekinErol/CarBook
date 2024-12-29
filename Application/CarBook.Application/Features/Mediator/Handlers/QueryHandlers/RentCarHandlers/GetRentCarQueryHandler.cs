using CarBook.Application.Features.Mediator.Queries.RentCarQueries;
using CarBook.Application.Features.Mediator.Results.RentCarResult;
using CarBook.Application.Interfaces.RentCarInterfaces;
using CarBook.Common.Models;
using CarBook.Shared.Extensions;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.QueryHandlers.RentCarHandlers
{
    public class GetRentCarQueryHandler : IRequestHandler<GetRentCarQuery, List<GetRentCarQueryResult>>
    {
        private readonly IRentCarRepository rentCarRepository;

        public GetRentCarQueryHandler(IRentCarRepository rentCarRepository)
        {
            this.rentCarRepository = rentCarRepository;
        }

        public async Task<List<GetRentCarQueryResult>> Handle(GetRentCarQuery request, CancellationToken cancellationToken)
        {
            // ✅ 1. LocationId Boş Kontrolü
            if (request.LocationId == 0 || request.LocationId < 0)
            {
                ErrorCodes.LocationIdRequired.Throw();
            }

            // ✅ 3. Araçların Varlığı Kontrolü
            var cars = await rentCarRepository.GetByFilter(x => x.LocationId == request.LocationId);

            if (cars.Count == 0)
            {
                ErrorCodes.LocationNotFound.Throw();
            }

            // ✅ 4. Uygun Araç Kontrolü
            var availableCars = cars.Where(x => x.CarAvailable == true).ToList();

            if (availableCars.Count == 0)
            {
                ErrorCodes.NoAvailableCars.Throw();
            }

            // ✅ 5. Başarı Durumu
            return availableCars.Select(x => new GetRentCarQueryResult
            {
                CarId = x.CarId
            }).ToList();
        }
    }
}
