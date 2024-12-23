using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces.BlogInterfaces
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetLast3BlogsWithAuthor();
        Task<List<Blog>> GetBlogsWithAuthor();
        Task<List<Blog>> GetBlogByAuthorId(int id);
    }
}
