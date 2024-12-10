using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using CarBook.Application.Features.CQRS.Results.ContactResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.QueryHandlers.ContactHandlers
{
    public class GetContactByIdQueryHandler
    {
        private readonly IRepository<Contact> repository;
        public GetContactByIdQueryHandler(IRepository<Contact> repository)
        {
            this.repository = repository;
        }
        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery query)
        {
            var data = await repository.GetByIdAsync(query.Id);
            return new GetContactByIdQueryResult
            {
                ContactId = data.Id,
                EMail = data.EMail,
                Message = data.Message,
                Name = data.Name,
                SendDate = data.SendDate,
                Subject = data.Subject,
                CreatedDate = data.CreatedDate,
                UpdatedDate = data.UpdatedDate
            };
        }
    }
}
