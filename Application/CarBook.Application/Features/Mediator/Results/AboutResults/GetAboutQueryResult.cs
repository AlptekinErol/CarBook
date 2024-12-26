﻿namespace CarBook.Application.Features.Mediator.Results.AboutResults
{
    public class GetAboutQueryResult
    {
        public int AboutId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}