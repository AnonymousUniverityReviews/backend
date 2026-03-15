using AnonymousStudentReviews.Api.Extensions;
using AnonymousStudentReviews.Core.Aggregates.Role;
using AnonymousStudentReviews.UseCases.Universities.AdminRetrieveMany;

using FluentValidation;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using OpenIddict.Validation.AspNetCore;

namespace AnonymousStudentReviews.Api.Features.Universities.AdminRetrieveMany;

[Authorize(
    AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme,
    Roles = RoleNameConstants.Admin)]
[Route("api/admin/universities")]
[ApiController]
public class AdminRetrieveManyUniversitiesController : ControllerBase
{
    private readonly IAdminRetrieveManyUniversitiesService _service;
    private readonly IValidator<AdminRetrieveManyUniversitiesQueryParameters> _validator;

    public AdminRetrieveManyUniversitiesController(
        IValidator<AdminRetrieveManyUniversitiesQueryParameters> validator,
        IAdminRetrieveManyUniversitiesService service)
    {
        _validator = validator;
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult> RetrieveManyAsync(
        [FromQuery] AdminRetrieveManyUniversitiesQueryParameters queryParameters)
    {
        var validationResult = await _validator.ValidateAsync(queryParameters);

        if (!validationResult.IsValid)
        {
            return validationResult.ToProblemDetails(Request.Path);
        }

        var result = await _service.HandleAsync(new AdminRetrieveManyUniversitiesDto
        {
            Limit = queryParameters.Limit,
            Offset = queryParameters.Offset,
            Query = queryParameters.Query,
            Name = queryParameters.Name,
            City = queryParameters.City,
            UniversitySortBy = queryParameters.SortBy,
            SortOrder = queryParameters.SortOrder
        });

        if (result.IsFailure)
        {
            return result.Error.ToProblemDetails(Request.Path);
        }

        return Ok(result.Value);
    }
}
