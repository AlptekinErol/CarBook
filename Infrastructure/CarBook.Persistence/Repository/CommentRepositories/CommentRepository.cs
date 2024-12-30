using CarBook.Application.Interfaces.CommentInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repository.CommentRepositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly CarBookContext context;
        public CommentRepository(CarBookContext context)
        {
            this.context = context;
        }
        public async Task<List<Comment>> GetCommentByBlogId(int id)
        {
            var data = context.Comments.Where(x => x.BlogId == id).ToList();
            return data;
        }

        public async Task<int> GetCommentCount(int id)
        {
            var data = await context.Comments.Where(x => x.BlogId == id).CountAsync();
            return data;
        }
    }
}
