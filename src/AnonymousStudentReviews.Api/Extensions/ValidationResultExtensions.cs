using FluentValidation.Results;

using Microsoft.AspNetCore.Mvc;

namespace AnonymousStudentReviews.Api.Extensions;

public static class ValidationResultExtensions
{
    public static ObjectResult ToProblemDetails(this ValidationResult validationResult)
    {
        var problemDetails = new ProblemDetails
        {
            Title = "Validation error",
            Status = StatusCodes.Status400BadRequest,
            Detail = "One or more validation errors have occured",
            Extensions = { { "errors", validationResult.ToDictionary() } }
        };

        return new ObjectResult(problemDetails)
        {
            ContentTypes = { "application/problem+json" }, StatusCode = StatusCodes.Status400BadRequest
        };
    }
}
