namespace CarBook.Application.Features.CQRS.Queries.AboutQueries
{
    public class GetAboutByIdQuery
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
