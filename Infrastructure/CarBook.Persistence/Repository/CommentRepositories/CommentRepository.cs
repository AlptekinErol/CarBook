using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;

namespace CarBook.Persistence.Repository.CommentRepositories
{
    public class CommentRepository : IGenericRepository<Comment>
    {
        private readonly CarBookContext context;

        public CommentRepository(CarBookContext context)
        {
            this.context = context;
        }

        public void Create(Comment entity)
        {
            context.Comments.Add(entity);
            context.SaveChanges();
        }

        public List<Comment> GetAll()
        {
            return context.Comments.Select(x => new Comment
            {
                Id = x.Id,
                BlogId = x.BlogId,
                Content = x.Content,
                Name = x.Name,
                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate,
            }).ToList();
        }

        public Comment GetById(int id)
        {
            return context.Comments.Find(id);
        }

        public void Remove(Comment entity)
        {
            var data = context.Comments.Find(entity.Id);
            context.Comments.Remove(data);
            context.SaveChanges();

        }

        public void Update(Comment entity)
        {
            context.Comments.Update(entity);
            context.SaveChanges();
        }
    }
}
