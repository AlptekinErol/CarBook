using CarBook.Application.Features.Mediator.Queries.FooterAddressQueries;
using CarBook.Application.Features.Mediator.Results.FooterAddressResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.QueryHandlers.FooterAddressHandlers
{
    public class GetFooterAddressQueryHandler : IRequestHandler<GetFooterAddressQuery, List<GetFooterAddressQueryResult>>
    {
        private readonly IRepository<FooterAddress> repository;
        public GetFooterAddressQueryHandler(IRepository<FooterAddress> repository)
        {
            this.repository = repository;
        }
        public async Task<List<GetFooterAddressQueryResult>> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
        {
            var data = await repository.GetAllAsync();
            return data.Select(x => new GetFooterAddressQueryResult
            {
                FooterAddressId = x.Id,
                Address = x.Address,
                Description = x.Description,
                EMail = x.EMail,
                Phone = x.Phone
            }).ToList();
        }
 
    }
}
