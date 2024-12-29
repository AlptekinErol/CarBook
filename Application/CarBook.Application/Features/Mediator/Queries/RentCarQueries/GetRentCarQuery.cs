using CarBook.Application.Features.Mediator.Results.RentCarResult;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.RentCarQueries
{
    public class GetRentCarQuery : IRequest<List<GetRentCarQueryResult>>
    {
        public int LocationId { get; set; }
        public bool CarAvailable { get; set; }
    }
}
