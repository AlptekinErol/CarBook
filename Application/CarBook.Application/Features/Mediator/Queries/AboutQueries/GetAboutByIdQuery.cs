using CarBook.Application.Features.Mediator.Results.AboutResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.AboutQueries
{
    public class GetAboutByIdQuery : IRequest<GetAboutByIdQueryResult>
    {
        // Ctor'da geçme sebebi:
        // 1- Güvenlik : veri sadece ctor'da atanabilir ve sonradan değiştirilemez, tutarlılık da sağlar
        // 2- Id Property'sini bir nevi Required olarak işaretliyoruz demektir
        public GetAboutByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }


    }
}
