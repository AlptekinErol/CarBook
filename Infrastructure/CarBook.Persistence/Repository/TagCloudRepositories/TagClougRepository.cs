using CarBook.Application.Interfaces.TagCloudInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;

namespace CarBook.Persistence.Repository.TagCloudRepositories
{
    public class TagClougRepository : ITagCloudRepository
    {
        private readonly CarBookContext context;
        public TagClougRepository(CarBookContext context)
        {
            this.context = context;
        }
        public  List<TagCloud> GetTagCloudsByBlogId(int id)
        {
            var data = context.TagClouds.Where(x => x.BlogId == id).ToList(); // TagCloudId eşit mi parametre id'ye => Listele
            return data;
        }
    }
}
