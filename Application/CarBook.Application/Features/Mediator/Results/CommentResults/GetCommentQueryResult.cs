namespace CarBook.Application.Features.Mediator.Results.CommentResults
{
    public class GetCommentQueryResult
    {
        public int CommentId { get; set; }
        public int BlogId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
    }
}
