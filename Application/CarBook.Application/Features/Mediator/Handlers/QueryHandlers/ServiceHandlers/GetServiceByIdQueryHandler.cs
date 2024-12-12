
using CarBook.Application.Features.Mediator.Queries.ServiceQueries;
using CarBook.Application.Features.Mediator.Results.ServiceResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.QueryHandlers.ServiceHandlers
{
    public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>
    {
        private readonly IRepository<Service> repository;
        public GetServiceByIdQueryHandler(IRepository<Service> repository)
        {
            this.repository = repository;
        }
        public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await repository.GetByIdAsync(request.Id);
            return new GetServiceByIdQueryResult
            {
                ServiceId = data.Id,
                Description = data.Description,
                IconUrl = data.IconUrl,
                Title = data.Title,
                CreatedDate = data.CreatedDate,
                UpdatedDate = data.UpdatedDate
            };
        }
    }
}
