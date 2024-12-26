using CarBook.Application.Features.Mediator.Queries.CarQueries;
using CarBook.Application.Features.Mediator.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.QueryHandlers.CarHandlers
{
    public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, GetCarByIdQueryResult>
    {
        private readonly IRepository<Car> repository;
        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            this.repository = repository;
        }
        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await repository.GetByIdAsync(request.Id);
            return new GetCarByIdQueryResult
            {
                BrandId = data.BrandId,
                CarId = data.Id,
                BigImageUrl = data.BigImageUrl,
                Fuel = data.Fuel,
                Km = data.Km,
                Luggage = data.Luggage,
                CoverImageUrl = data.CoverImageUrl,
                Model = data.Model,
                Seat = data.Seat,
                Transmission = data.Transmission
            };
        }
    }
}
