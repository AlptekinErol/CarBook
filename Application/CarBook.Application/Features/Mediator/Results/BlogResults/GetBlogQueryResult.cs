﻿using CarBook.Domain.Entities;

namespace CarBook.Application.Features.Mediator.Results.BlogResults
{
    public class GetBlogQueryResult
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
