using CarBook.Application.Features.CQRS.Results.ContactResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.QueryHandlers.ContactHandlers
{
    public class GetContactQueryHandler
    {
        private readonly IRepository<Contact> repository;
        public GetContactQueryHandler(IRepository<Contact> repository)
        {
            this.repository = repository;
        }
        public async Task<List<GetContactQueryResult>> Handle()
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
