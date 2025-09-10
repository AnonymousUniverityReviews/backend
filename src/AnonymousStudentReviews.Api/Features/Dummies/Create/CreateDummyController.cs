using System.Data;

using AnonymousStudentReviews.Api.Extensions;
using AnonymousStudentReviews.UseCases.Dummies.Create;

using FluentValidation;

using Microsoft.AspNetCore.Mvc;

namespace AnonymousStudentReviews.Api.Features.Dummies.Create;

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
            return validationResult.ToProblemDetails(Request.Path);
        }

        var createDummyResult = await _createDummyService.ExecuteAsync(RequestToDto(request));

        if (createDummyResult.IsFailure)
        {
            return createDummyResult.Error.ToProblemDetails(Request.Path);
        }

        return CreatedAtAction(nameof(CreateDummy), createDummyResult.Value);
    }

    [HttpGet]
    public async Task<ActionResult> TestException()
    {
        throw new DBConcurrencyException();
    }

    private CreateDummyDto RequestToDto(CreateDummyRequest request)
    {
        return new CreateDummyDto { Name = request.Name };
    }
}
