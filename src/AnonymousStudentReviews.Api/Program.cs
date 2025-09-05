using AnonymousStudentReviews.Api.Configurations;

using Serilog;
using Serilog.Core;
using Serilog.Extensions.Logging;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

logger.Information("Starting web host");

builder.AddLoggerConfigs();

var appLogger = new SerilogLoggerFactory(logger)
    .CreateLogger<Program>();

builder.Services.AddControllers();

builder.Services.AddSwaggerConfig();

builder.Services.AddServiceConfigs(appLogger, builder);

WebApplication app = builder.Build();

app.UseAppMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program
{
}