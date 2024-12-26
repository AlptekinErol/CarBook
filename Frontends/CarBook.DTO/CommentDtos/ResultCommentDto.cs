namespace CarBook.DTO.CommentDtos
{
    public class ResultCommentDto
    {
        public int CommentId { get; set; }
        public int BlogId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
