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
            return context.Comments.ToList();
        }

        public Comment GetById(int id)
        {
            return context.Comments.Find(id);
        }

        public void Remove(Comment entity)
        {
            context.Comments.Remove(entity);
            context.SaveChanges();

        }

        public void Update(Comment entity)
        {
            context.Comments.Update(entity);
            context.SaveChanges();
        }
    }
}
