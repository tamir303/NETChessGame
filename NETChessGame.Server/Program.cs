using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Load Configuration
var configuration = builder.Configuration;

// Configure Services
ConfigureServices(builder.Services, configuration);

var app = builder.Build();

// Configure Middleware and Pipeline
ConfigureMiddleware(app);

app.Run();

// Method to Configure Services
void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    // Add Controllers
    services.AddControllers();

    // Add Swagger for API Documentation
    services.AddEndpointsApiExplorer();

    // Add CORS (Cross-Origin Resource Sharing)
    services.AddCors(options =>
    {
        options.AddPolicy("AllowAll", policy =>
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader());
    });

    // Add Logging
    services.AddLogging(logging =>
    {
        logging.ClearProviders();
        logging.AddConsole();
        logging.AddDebug();
    });

    // Register other services (e.g., Database, Authentication, etc.)
    // services.AddDbContext<YourDbContext>(options => 
    //     options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

    // Example: Dependency Injection for a custom service
    // services.AddScoped<IYourService, YourService>();
}

// Method to Configure Middleware and Request Pipeline
void ConfigureMiddleware(WebApplication app)
{
    // Use Swagger in Development
    if (app.Environment.IsDevelopment())
    {

    }

    // Use CORS
    app.UseCors("AllowAll");

    // Enable HTTPS Redirection
    app.UseHttpsRedirection();

    // Use Authorization Middleware
    app.UseAuthorization();

    // Map Controller Routes
    app.MapControllers();
}