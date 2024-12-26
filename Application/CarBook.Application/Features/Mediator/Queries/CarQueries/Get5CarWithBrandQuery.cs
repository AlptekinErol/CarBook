using CarBook.Application.Features.Mediator.Results.CarResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.CarQueries
{
    public class Get5CarWithBrandQuery : IRequest<List<Get5CarWithBrandQueryResult>>
    {
    }
}
