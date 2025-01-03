﻿namespace CarBook.DTO.BlogDtos
{
    public class UpdateBlogDto
    {
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string CategoryName { get; set; }
        public string CoverImageUrl { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public string AuthorDescription { get; set; }
        public string AuthorImageUrl { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
