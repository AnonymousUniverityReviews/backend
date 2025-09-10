using AnonymousStudentReviews.Api.Dummies.Create;
using AnonymousStudentReviews.Infrastructure;
using AnonymousStudentReviews.UseCases;

using FluentValidation;

namespace AnonymousStudentReviews.Api.Configurations;

public static class ServiceConfig
{
    public static IServiceCollection AddServiceConfigs(this IServiceCollection services,
        ILogger logger,
        WebApplicationBuilder builder)
    {
        services
            .AddExceptionHandler<GlobalExceptionHandler>()
            .AddProblemDetails()
            .AddInfrastructureServices(builder.Configuration, logger, builder.Environment.EnvironmentName)
            .AddUseCasesServices(builder.Configuration, logger, builder.Environment.EnvironmentName)
            .AddValidatorsFromAssemblyContaining<CreateDummyRequestValidator>();

        logger.LogInformation("Infrastructure services registered");

        return services;
    }
}
