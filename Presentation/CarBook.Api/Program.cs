using CarBook.Application.Features.CQRS.Handlers.CommandHandlers.AboutHandlers;
using CarBook.Application.Features.CQRS.Handlers.QueryHandlers.AboutHandlers;
using CarBook.Application.Interfaces;
using CarBook.Bootstrapper.Extensions;
using CarBook.Persistence.Context;
using CarBook.Persistence.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<CarBookContext>();

//RepositoryExtensions Registration
builder.Services.RepositoryRegister();

//HandlerExtensions Registration
builder.Services.HandlerRegister();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
