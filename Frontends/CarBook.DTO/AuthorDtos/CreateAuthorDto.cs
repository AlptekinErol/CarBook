namespace CarBook.DTO.AuthorDtos
{
    public class CreateAuthorDto
    {
        public string AuthorName { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
