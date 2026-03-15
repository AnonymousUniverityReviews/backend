using FluentValidation;

namespace AnonymousStudentReviews.Api.Features.Universities.AdminRetrieveMany;

public class AdminRetrieveManyUniversitiesQueryParametersValidator
    : AbstractValidator<AdminRetrieveManyUniversitiesQueryParameters>
{
    public AdminRetrieveManyUniversitiesQueryParametersValidator()
    {
        RuleFor(x => x.Limit)
            .InclusiveBetween(1, 100);

        RuleFor(x => x.Offset)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.City)
            .MinimumLength(1)
            .MaximumLength(255);

        RuleFor(x => x.Name)
            .MinimumLength(1)
            .MaximumLength(255);
    }
}
