using CarBook.Application.Features.Mediator.Queries.ContactQueries;
using CarBook.Application.Features.Mediator.Results.ContactResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.QueryHandlers.ContactHandlers
{
    public class GetContactQueryHandler : IRequestHandler<GetContactQuery, List<GetContactQueryResult>>
    {
        private readonly IRepository<Contact> repository;
        public GetContactQueryHandler(IRepository<Contact> repository)
        {
            this.repository = repository;
        }
        public async Task<List<GetContactQueryResult>> Handle(GetContactQuery request, CancellationToken cancellationToken)
        {
            var data = await repository.GetAllAsync();
            return data.Select(x => new GetContactQueryResult
            {
                ContactId = x.Id,
                EMail = x.EMail,
                Message = x.Message,
                Name = x.Name,
                SendDate = x.SendDate,
                Subject = x.Subject,
                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate
            }).ToList();
        }
    }
}
