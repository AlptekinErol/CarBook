using CarBook.Application.Features.Mediator.Queries.ContactQueries;
using CarBook.Application.Features.Mediator.Results.ContactResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.QueryHandlers.ContactHandlers
{
    public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, GetContactByIdQueryResult>
    {
        private readonly IRepository<Contact> repository;
        public GetContactByIdQueryHandler(IRepository<Contact> repository)
        {
            this.repository = repository;
        }
        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await repository.GetByIdAsync(request.Id);
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
