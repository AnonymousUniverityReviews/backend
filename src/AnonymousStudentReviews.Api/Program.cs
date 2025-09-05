using AnonymousStudentReviews.Api.Configurations;

using Serilog;
using Serilog.Core;
using Serilog.Extensions.Logging;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

Logger logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

logger.Information("Starting web host");

builder.AddLoggerConfigs();

ILogger<Program> appLogger = new SerilogLoggerFactory(logger)
    .CreateLogger<Program>();

builder.Services.AddControllers();

builder.Services.AddSwaggerConfig();

builder.Services.AddServiceConfigs(appLogger, builder);

WebApplication app = builder.Build();


if (app.Environment.IsDevelopment() && MigrationConfig.ShouldApplyMigrationsOnStartup(app.Configuration, appLogger))
{
    app.UseMigrations(appLogger);
}

app.UseAppMiddleware();

app.Run();

public partial class Program
{
}