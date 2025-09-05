using AnonymousStudentReviews.Infrastructure;

namespace AnonymousStudentReviews.Api.Configurations;

public static class ServiceConfig
{
    public static IServiceCollection AddServiceConfigs(this IServiceCollection services,
        ILogger logger,
        WebApplicationBuilder builder)
    {
        services
            .AddInfrastructureServices(builder.Configuration, logger, builder.Environment.EnvironmentName);

        logger.LogInformation("Infrastructure services registered");

        return services;
    }
}