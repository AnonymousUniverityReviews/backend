using AnonymousStudentReviews.Api.Extensions;
using AnonymousStudentReviews.Core.Aggregates.Role;
using AnonymousStudentReviews.UseCases.Universities.UploadIcon;

using FluentValidation;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using OpenIddict.Validation.AspNetCore;

namespace AnonymousStudentReviews.Api.Features.Universities.UploadIcon;

[Authorize(
    AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme,
    Roles = RoleNameConstants.Admin)]
[ApiController]
[Route("api/universities/icon")]
public class UploadUniversityIconController : ControllerBase
{
    private readonly IValidator<UploadUniversityIconRequest> _validator;
    private readonly IUploadUniversityIconService _service;

    public UploadUniversityIconController(
        IValidator<UploadUniversityIconRequest> validator,
        IUploadUniversityIconService service)
    {
        _validator = validator;
        _service = service;
    }

    [HttpPost]
    [Consumes("multipart/form-data")]
    [ProducesResponseType(typeof(UploadUniversityIconResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<UploadUniversityIconResponse>> Upload(
        [FromForm] UploadUniversityIconRequest request)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return validationResult.ToProblemDetails(Request.Path);
        }

        await using var fileStream = request.File.OpenReadStream();

        var result = await _service.ExecuteAsync(new UploadUniversityIconDto
        {
            FileName = request.File.FileName,
            FileStream = fileStream
        });

        if (result.IsFailure)
        {
            return result.Error.ToProblemDetails(Request.Path);
        }

        return Ok(new UploadUniversityIconResponse
        {
            IconUrl = result.Value
        });
    }
}
