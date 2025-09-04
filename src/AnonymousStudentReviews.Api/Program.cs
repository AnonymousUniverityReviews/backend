using AnonymousStudentReviews.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerConfig();

var app = builder.Build();

app.UseAppMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();