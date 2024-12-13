﻿using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.LocationCommands
{
    public class CreateLocationCommand:IRequest
    {
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}