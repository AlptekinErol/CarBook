﻿namespace CarBook.Application.Features.Mediator.Results.CategoryResults
{
    public class GetCategoryQueryResult
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}