var builder = WebApplication.CreateBuilder(args);

// Build Startup
var startup = new Startup(builder.Configuration);

// Startup üzerinden çaðýr ConfigureServices
startup.ConfigureServices(builder.Services);

var app = builder.Build();

// Startup üzerinden çaðýr Configure
startup.Configure(app, app.Environment);

app.Run();
