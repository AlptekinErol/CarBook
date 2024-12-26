using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces.CommentInterfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetCommentByBlogId(int id);
    }
}
