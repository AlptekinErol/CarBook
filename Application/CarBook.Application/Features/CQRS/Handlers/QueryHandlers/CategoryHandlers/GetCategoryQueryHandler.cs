using CarBook.Application.Features.CQRS.Results.CategoryResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.QueryHandlers.CategoryHandlers
{
    public class GetCategoryQueryHandler
    {
        private readonly IRepository<Category> repository;
        public GetCategoryQueryHandler(IRepository<Category> repository)
        {
            this.repository = repository;
        }
        /// <summary>
        /// Burada neden List ile çalıştık ve neden data.Select kullanıldı?
        /// List olmasının sebebi tek bir veri değilde ilgili tüm kategoriler dönülüyor bu da list olmalı
        /// Select Linq sorgusu ile ilgili data Db'den geldikten sonra datayı direkt olarak dışarı aktarmak yerine result sınıfı kullanılarak 
        /// newledik ve sadece result sınıfını dışarıya verdik, ana domain dışarı verilmedi
        /// </summary>
        /// <returns></returns>
        public async Task<List<GetCategoryQueryResult>> Handle()
        {
            var data = await repository.GetAllAsync();
            return data.Select(x => new GetCategoryQueryResult
            {
                CategoryId = x.Id,
                Name = x.Name,
                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate,
            }).ToList();
        }
    }
}
