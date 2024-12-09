using CarBook.Application.Features.CQRS.Handlers.CommandHandlers.AboutHandlers;
using CarBook.Application.Features.CQRS.Handlers.QueryHandlers.AboutHandlers;
using CarBook.Application.Interfaces;
using CarBook.Persistence.Context;
using CarBook.Persistence.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<CarBookContext>();
builder.Services.AddScoped(typeof (IRepository<>), typeof(Repository<>)); // burada typeof repo classlarýn <T> yani generic çalýþacaðýný belirtmemizi saðlýyor
builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<GetAboutQueryHandler>();
builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<RemoveAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();

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
