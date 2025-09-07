using FluentValidation;

namespace AnonymousStudentReviews.Api.Dummies.Create;

public class CreateDummyRequestValidator : AbstractValidator<CreateDummyRequest>
{
    public CreateDummyRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .Length(0, 20);
    }
}
