﻿using CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook.Application.Features.Mediator.Queries.ServiceQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IMediator mediator;
        public ServiceController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ServiceList()
        {
            var data = await mediator.Send(new GetServiceQuery());
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetService(int id)
        {
            var data = await mediator.Send(new GetServiceByIdQuery(id));
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceCommand command)
        {
            await mediator.Send(command);
            return Ok("Service Created");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateService(UpdateServiceCommand command)
        {
            await mediator.Send(command);
            return Ok("Service Updated");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveService(RemoveServiceCommand command)
        {
            await mediator.Send(command);
            return Ok("Service Deleted");
        }
    }
}
