﻿using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.AboutCommands
{
    public class UpdateAboutCommand : IRequest
    {
        public int AboutId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
