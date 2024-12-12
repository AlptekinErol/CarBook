using CarBook.Bootstrapper.Extensions;
using CarBook.Persistence.Context;

public class Startup
{
    private readonly IConfiguration configuration;

    // Program.cs de Startup.cs üzerinden nesne oluşturulurken bu ctor parametreyi zorunlu hale getiriyor ( program.cs de çağırılırken parametre )
    public Startup(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // Add services to the container.
        services.AddScoped<CarBookContext>();

        // RepositoryExtensions Registration
        services.RepositoryRegister();

        // HandlerExtensions Registration
        services.HandlerRegister();

        // MediatR Registration
        services.MediatRRegistration(configuration);

        // Add Controllers
        services.AddControllers();

        // Swagger/OpenAPI
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public void Configure(WebApplication app, IWebHostEnvironment env)
    {
        // Configure the HTTP request pipeline.
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
    }
}
