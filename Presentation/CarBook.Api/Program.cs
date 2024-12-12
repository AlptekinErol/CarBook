var builder = WebApplication.CreateBuilder(args);

// Build Startup
var startup = new Startup(builder.Configuration);

// Startup �zerinden �a��r ConfigureServices
startup.ConfigureServices(builder.Services);

var app = builder.Build();

// Startup �zerinden �a��r Configure
startup.Configure(app, app.Environment);

app.Run();
