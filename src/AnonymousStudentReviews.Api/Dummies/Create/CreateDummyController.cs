using AnonymousStudentReviews.Api.Extensions;
using AnonymousStudentReviews.UseCases.Dummies.Create;

using FluentValidation;

using Microsoft.AspNetCore.Mvc;

namespace AnonymousStudentReviews.Api.Dummies.Create;

[ApiController]
[Route("api/dummies")]
public class CreateDummyController : ControllerBase
{
    private readonly IValidator<CreateDummyRequest> _createDummyRequestValidator;
    private readonly ICreateDummyService _createDummyService;

    public CreateDummyController(IValidator<CreateDummyRequest> createDummyRequestValidator,
        ICreateDummyService createDummyService)
    {
        _createDummyRequestValidator = createDummyRequestValidator;
        _createDummyService = createDummyService;
    }

    [HttpPost]
    public async Task<ActionResult<CreateDummyResponse>> CreateDummy([FromBody] CreateDummyRequest request)
    {
        var validationResult = await _createDummyRequestValidator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return validationResult.ToProblemDetails();
        }

        var createDummyResult = await _createDummyService.ExecuteAsync(RequestToDto(request));

        if (createDummyResult.IsFailure)
        {
            var errorCode = createDummyResult.Error.Code;
            var errorName = createDummyResult.Error.Name;

            if (createDummyResult.Error.Code == CreateDummyErrors.SomeError.Code)
            {
                return Problem(
                    errorName,
                    "api/dummies",
                    StatusCodes.Status403Forbidden,
                    errorCode,
                    "");
            }
        }

        return CreatedAtAction(nameof(CreateDummy), createDummyResult.Value);
    }

    private CreateDummyDto RequestToDto(CreateDummyRequest request)
    {
        return new CreateDummyDto { Name = request.Name };
    }
}
