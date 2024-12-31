namespace CarBook.DTO.CommentDtos
{
    public class CreateCommentDto
    {
        public int BlogId { get; set; }
        public string Name { get; set; }
        public string EMail { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
